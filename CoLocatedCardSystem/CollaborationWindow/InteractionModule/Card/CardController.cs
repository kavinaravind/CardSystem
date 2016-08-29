using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
using CoLocatedCardSystem.CollaborationWindow.FileLoaderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    public class CardController
    {
        CentralControllers controllers;
        ItemCardController itemCardController = null;
        DocumentCardController semanticCardController = null;
        ClusterCardController clusterCardController = null;
        PlotCardController plotCardController = null;

        public CardController(CentralControllers ctrls) {
            this.controllers = ctrls;
        }
        internal async Task<Card[]> Init(Document[] docs, Item[] items, FileLoaderModule.Attribute[] attrs)
        {
            itemCardController = new ItemCardController(controllers);
            semanticCardController = new DocumentCardController(controllers);
            List<Card> cardToShow = new List<Card>();
            if (docs != null)
            {
                Card[] docCards = await semanticCardController.Init(docs);
                foreach (Card c in docCards)
                {
                    cardToShow.Add(c);
                }
            }
            if (items != null)
            {
                Card[] itemCards = await itemCardController.Init(items);
                foreach (Card c in itemCards)
                {
                    cardToShow.Add(c);
                }
            }
            return cardToShow.ToArray();
        }
        internal async void Deinit() {
            itemCardController.Deinit();
        }      
        /// <summary>
        /// Create a touch and pass it to the interaction controller.
        /// </summary>
        /// <param name="p"></param>
        internal void PointerDown(PointerPoint localPoint, PointerPoint globalPoint, Card card, Type type)
        {
            controllers.TouchController.TouchDown(localPoint,globalPoint, card, type);
        }
        /// <summary>
        /// Update the touch point
        /// </summary>
        /// <param name="p"></param>
        internal void PointerMove(PointerPoint localPoint, PointerPoint globalPoint)
        {
            controllers.TouchController.TouchMove(localPoint, globalPoint);
        }
        /// <summary>
        /// Lift the touch layer
        /// </summary>
        /// <param name="p"></param>
        internal void PointerUp(PointerPoint localPoint, PointerPoint globalPoint)
        {
            controllers.TouchController.TouchUp(localPoint, globalPoint);
        }
        /// <summary>
        /// Update the ZIndex of the card. Move the card to the top.
        /// </summary>
        /// <param name="card"></param>
        internal void MoveCardToTop(Card card)
        {
            controllers.CardLayerController.MoveCardToTop(card);
        }
    }
}
