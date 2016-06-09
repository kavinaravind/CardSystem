using CoLocatedCardSystem.CollaborationWindow.InteractionModule;
using CoLocatedCardSystem.CollaborationWindow.Layers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;

namespace CoLocatedCardSystem.CollaborationWindow
{
    public class ViewControllers
    {
        InteractionControllers interactionControllers;
        BaseLayerController baseLayerController;
        CardLayerController cardLayerController;
        LinkingLayerController linkingLayerController;
        MenuLayerController menuLayerController;
        SortingBoxLayerController sortingBoxController;
        
        /// <summary>
        /// Initialize the views, including different layers.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="interactionControllers"></param>
        public void Init(int width, int height, InteractionControllers interactionControllers)
        {
            this.interactionControllers = interactionControllers;
            baseLayerController = new BaseLayerController(this);
            baseLayerController.Init(width, height);
            cardLayerController = new CardLayerController(this);
            cardLayerController.Init(width, height);
        }
        public void Deinit()
        {
            cardLayerController.Deinit();
            cardLayerController = null;
            baseLayerController.Deinit();
            baseLayerController = null;
        }
        /// <summary>
        /// Get the base layer
        /// </summary>
        /// <returns></returns>
        internal BaseLayer GetBaseLayer()
        {
            return baseLayerController.BaseLayer;
        }
        /// <summary>
        /// Get the card layer
        /// </summary>
        /// <returns></returns>
        internal CardLayer GetCardLayer()
        {
            return cardLayerController.CardLayer;
        }
        /// <summary>
        /// Add all the cards to the card layer
        /// </summary>
        /// <param name="cards"></param>
        internal async Task LoadCardsToCardLayer(Card[] cards) {
            await cardLayerController.LoadCards(cards);
        }
        /// <summary>
        /// Pass the PointerPoint to the TouchController
        /// </summary>
        /// <param name="baseLayer"></param>
        /// <param name="p"></param>
        internal void OnTouchDown(PointerPoint p,object sender, Type type)
        {
            interactionControllers.OnTouchDown(p, sender, type);
        }

        /// <summary>
        /// Update the touch
        /// </summary>
        /// <param name="p"></param>
        internal void OnTouchMove(PointerPoint p)
        {
            interactionControllers.OnTouchMove(p);
        }

        /// <summary>
        /// Release the touch
        /// </summary>
        /// <param name="p"></param>
        internal void OnTouchUp(PointerPoint p)
        {
            interactionControllers.OnTouchUp(p);
        }

        /// <summary>
        /// Move the card to the top in the card layer.
        /// </summary>
        /// <param name="card"></param>
        internal void MoveCardToTop(Card card)
        {
            cardLayerController.MoveCardToTop(card);
        }
    }
}
