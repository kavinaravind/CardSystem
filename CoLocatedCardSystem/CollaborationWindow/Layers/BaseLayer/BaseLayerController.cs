using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;

namespace CoLocatedCardSystem.CollaborationWindow.Layers
{
    /// <summary>
    /// Controller class for the invisible layer at the bottom
    /// </summary>
    class BaseLayerController
    {
        private BaseLayer baseLayer;
        private ViewControllers viewControllers;

        internal BaseLayer BaseLayer
        {
            get
            {
                return baseLayer;
            }
        }

        public BaseLayerController(ViewControllers vctrl)
        {
            viewControllers = vctrl;
        }
        /// <summary>
        /// Initialize the card layer
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Init(int width, int height)
        {
            baseLayer = new BaseLayer(this);
            baseLayer.Init(width, height);
        }
        /// <summary>
        /// Destroy the base layer
        /// </summary>
        public void Deinit()
        {
            baseLayer.Deinit();
        }
        /// <summary>
        /// Pass the touch point from the base layer to the view controller
        /// </summary>
        /// <param name="p"></param>
        internal void PointerDown(PointerPoint p)
        {
            viewControllers.OnTouchDown(p, baseLayer, typeof(BaseLayer));
        }
        /// <summary>
        /// Update the touch point
        /// </summary>
        /// <param name="p"></param>
        internal void PointerMove(PointerPoint p)
        {
            viewControllers.OnTouchMove(p);
        }
        /// <summary>
        /// End the touch point
        /// </summary>
        /// <param name="p"></param>
        internal void PointerUp(PointerPoint p)
        {
            viewControllers.OnTouchUp(p);
        }
    }
}
