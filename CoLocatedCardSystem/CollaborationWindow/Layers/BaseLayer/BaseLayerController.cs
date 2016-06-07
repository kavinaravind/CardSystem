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
        public void Init(int width, int height)
        {
            baseLayer = new BaseLayer(this);
            baseLayer.Init(width, height);
        }
        public void Deinit()
        {
            baseLayer.Deinit();
        }
        internal void PointerDown(PointerPoint p)
        {
            viewControllers.PointerDown(typeof(BaseLayer), baseLayer, p);
        }
        internal void PointerMove(PointerPoint p)
        {
            viewControllers.PointerMove(p);
        }
        internal void PointerUp(PointerPoint p)
        {
            viewControllers.PointerUp(p);
        }
    }
}
