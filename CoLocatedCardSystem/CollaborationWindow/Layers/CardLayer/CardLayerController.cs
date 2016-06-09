using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoLocatedCardSystem.CollaborationWindow.InteractionModule;

namespace CoLocatedCardSystem.CollaborationWindow.Layers
{
    /// <summary>
    /// A controller to manage the card layer
    /// </summary>
    class CardLayerController
    {
        CardLayer cardLayer;
        private ViewControllers viewControllers;
        Dictionary<Card, int> zIndexList = new Dictionary<Card, int>();

        internal CardLayer CardLayer
        {
            get
            {
                return cardLayer;
            }
        }

        public CardLayerController(ViewControllers vctrl)
        {
            this.viewControllers = vctrl;
        }
        /// <summary>
        /// Initialize the CardLayer
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Init(int width, int height)
        {
            cardLayer = new CardLayer(this);
            cardLayer.Init(width, height);
        }
        /// <summary>
        /// Destroy the CardLayer
        /// </summary>
        public void Deinit()
        {
            cardLayer.Deinit();
        }
        /// <summary>
        /// Load the card list to the card layer
        /// </summary>
        /// <param name="cards"></param>
        internal async Task LoadCards(Card[] cards)
        {
            int index = zIndexList.Count();
            foreach (Card card in cards) {
                await cardLayer.AddCard(card);
                zIndexList.Add(card, index++);
                cardLayer.SetZIndex(card, zIndexList[card]);
            }
        }
        /// <summary>
        /// Update the card zindex in the cardlayer
        /// </summary>
        /// <param name="card"></param>
        internal void MoveCardToTop(Card card)
        {
            if (zIndexList.Keys.Contains(card)) {
                int currentIndex = zIndexList[card];
                foreach (Card child in cardLayer.Children)
                {
                    if (zIndexList[child] > currentIndex)
                    {
                        zIndexList[child]--;
                        cardLayer.SetZIndex(child, zIndexList[child]);
                    }
                }
                zIndexList[card] = zIndexList.Count - 1;
                cardLayer.SetZIndex(card, zIndexList[card]);
            }
        }
    }
}
