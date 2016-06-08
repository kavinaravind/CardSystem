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
        internal CardLayer GetCardLayer()
        {
            return cardLayerController.CardLayer;
        }
        /// <summary>
        /// Pass the PointerPoint to the TouchController
        /// </summary>
        /// <param name="baseLayer"></param>
        /// <param name="p"></param>
        internal void PointerDown(PointerPoint p,object sender, Type type)
        {
            interactionControllers.OnTouchDown(p, sender, type);
        }
        /// <summary>
        /// Update the touch
        /// </summary>
        /// <param name="p"></param>
        internal void PointerMove(PointerPoint p)
        {
            interactionControllers.OnTouchMove(p);
        }

        /// <summary>
        /// Release the touch
        /// </summary>
        /// <param name="p"></param>
        internal void PointerUp(PointerPoint p)
        {
            interactionControllers.OnTouchUp(p);
        }
    }
}
