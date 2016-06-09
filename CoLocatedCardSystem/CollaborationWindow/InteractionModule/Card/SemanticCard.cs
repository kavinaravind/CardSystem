using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Input;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    public class SemanticCard:Card
    {
        User owner = User.ALEX;
        LayerBase[] layers;
        int currentLayer;
        Document document;
        private const int LAYER_NUMBER= 4;

        public SemanticCard(CardController cardController) : base(cardController)
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
        internal override async void Init(string cardID, UserInfo userInfo)
        {
            base.Init(cardID, userInfo);
            layers = new LayerBase[LAYER_NUMBER];
            layers[0] = new Layer1(this);
            layers[1] = new Layer2(this);
            layers[2] = new Layer3(this);
            layers[3] = new Layer4(this);
            foreach (var layer in layers) {
                await layer.Init();
            }
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
        /// Get the document associated with the card.
        /// </summary>
        /// <returns></returns>
        internal Document GetDocument() {
            return document;
        }
        protected override void PointerDown(object sender, PointerRoutedEventArgs e)
        {
            base.PointerDown(sender, e);
            System.Diagnostics.Debug.WriteLine("touchDown:" + this.document.GetTitle());
        }
    }
}
