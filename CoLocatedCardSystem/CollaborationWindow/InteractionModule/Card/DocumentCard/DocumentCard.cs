using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
using System;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Input;
using Windows.UI.Xaml.Input;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    public class DocumentCard:Card
    {
        User owner = User.ALEX;
        DocumentCardLayerBase[] layers;
        int currentLayer;
        Document document;
        private const int LAYER_NUMBER= 4;

        public User Owner
        {
            get
            {
                return owner;
            }

            set
            {
                owner = value;
            }
        }

        public Document Document
        {
            get
            {
                return document;
            }

            set
            {
                document = value;
            }
        }

        public DocumentCard(CardController cardController) : base(cardController)
        {
        }

        /// <summary>
        /// Initialize a semantic card.
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <param name="rotation"></param>
        internal override void Init(string cardID, User user)
        {
            base.Init(cardID, user);
            this.owner = user;
            layers = new DocumentCardLayerBase[LAYER_NUMBER];
            layers[0] = new DocumentCardLayer1(this);
            layers[1] = new DocumentCardLayer2(this);
            layers[2] = new DocumentCardLayer3(this);
            layers[3] = new DocumentCardLayer4(this);
            foreach (var layer in layers) {
                layer.Init();
            }
            currentLayer = 0;
            this.Children.Add(layers[0]);
        }
        /// <summary>
        /// Load the document to the card. Set the content to all the layers.
        /// </summary>
        /// <param name="document"></param>
        internal async Task LoadDocument(Document document) {
            this.document = document;
            foreach (var layer in layers)
            {
                await layer.SetArticle(this.document);
            }
        }

        /// <summary>
        /// Send a new touch to the touch module, with the type of Document Card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void PointerDown(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint localPoint = e.GetCurrentPoint(this);
            PointerPoint globalPoint = e.GetCurrentPoint(Coordination.Baselayer);
            CardController.PointerDown(localPoint, globalPoint, this, typeof(DocumentCard));
        }
        /// <summary>
        /// Check the size of the card, load new layer if necessary
        /// </summary>
        internal override void UpdateSize()
        {
            base.UpdateSize();
            UpdateLayer(this.CardScale);
        }
        private void UpdateLayer(double scale)
        {
            if (scale > 3 && currentLayer != 3)
            {
                ShowLayer(3);
            }
            else if (scale > 2 && scale <= 3 && currentLayer != 2)
            {
                ShowLayer(2);
            }
            else if (scale > 1 && scale <= 2 && currentLayer != 1)
            {
                ShowLayer(1);
            }
            else if (scale <= 1 && currentLayer != 0)
            {
                ShowLayer(0);
            }
        }
        private async void ShowLayer(int layerIndex)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Children.Remove(layers[currentLayer]);
                currentLayer = layerIndex;
                this.Children.Add(layers[currentLayer]);
            });
        }
    }
}
