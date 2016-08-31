using CoLocatedCardSystem.CollaborationWindow.TableModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Input;
using Windows.UI.Xaml.Input;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    class ItemCard:Card
    {
        User owner = User.ALEX;
        ItemCardLayerBase[] layers;
        int currentLayer;
        Item item;
        private const int LAYER_NUMBER = 2;

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

        internal Item Item
        {
            get
            {
                return item;
            }

            set
            {
                item = value;
            }
        }

        public ItemCard(CardController cardController) : base(cardController)
        {
        }

        /// <summary>
        /// Initialize an item card.
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
            layers = new ItemCardLayerBase[LAYER_NUMBER];
            layers[0] = new ItemCardLayer1(this);
            layers[1] = new ItemCardLayer2(this);
            foreach (var layer in layers)
            {
                layer.Init();
            }
            this.Children.Add(layers[0]);
        }
        /// <summary>
        /// Send a new touch to the touch module, with the type of Item Card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void PointerDown(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint localPoint = e.GetCurrentPoint(this);
            PointerPoint globalPoint = e.GetCurrentPoint(Coordination.Baselayer);
            CardController.PointerDown(localPoint, globalPoint, this, typeof(ItemCard));
        }
        /// <summary>
        /// Load the document to the card. Set the content to all the layers.
        /// </summary>
        /// <param name="document"></param>
        internal async Task LoadItem(Item item)
        {
            this.item = item;
            foreach (var layer in layers)
            {
                await layer.SetItem(this.item);
            }
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
            if (scale > 2 && currentLayer == 0)
            {
                ShowLayer(1);
            }
            else if (scale <= 2 && currentLayer == 1)
            {
                ShowLayer(0);
            }
        }
        private async void ShowLayer(int layerIndex)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                this.Children.Remove(layers[currentLayer]);
                currentLayer = layerIndex;
                this.Children.Add(layers[currentLayer]);
            });
        }
    }
}
