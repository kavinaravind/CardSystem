using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace CoLocatedCardSystem.CollaborationWindow.Layers
{
    class MenuLayer : Canvas
    {
        MenuLayerController menulayerController;
        internal MenuLayer(MenuLayerController mlcltr)
        {
            this.menulayerController = mlcltr;
        }
        /// <summary>
        /// Initialize the menu layer.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        internal void Init(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        /// <summary>
        /// Add a menubar to the layer
        /// </summary>
        /// <param name="menubar"></param>
        internal void AddMenuBar(MenuBar menubar) {
            this.Children.Add(menubar);
        }
    }
}
