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
    class ViewControllers
    {
        BaseLayerController baseLayerController;
        CardLayerController cardLayerController;
        LinkingLayerController linkingLayerController;
        MenuLayerController menuLayerController;
        SortingBoxLayerController sortingBoxController;

        public void Init(int width, int height)
        {
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
        internal void PointerDown(Type type, object sender, PointerPoint p)
        {
            //Debug.WriteLine("Down:\t" + type.Name + "\t" + p.Position.ToString());
        }
        /// <summary>
        /// Update the touch
        /// </summary>
        /// <param name="p"></param>
        internal void PointerMove(PointerPoint p)
        {
            //Debug.WriteLine("Move:\t" + p.Position.ToString());
        }

        /// <summary>
        /// Release the touch
        /// </summary>
        /// <param name="p"></param>
        internal void PointerUp(PointerPoint p)
        {
            //Debug.WriteLine("Up:\t" + p.Position.ToString());
        }
    }
}
