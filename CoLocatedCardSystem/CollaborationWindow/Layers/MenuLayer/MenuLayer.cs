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
        Dictionary<User, MenuBar> menubars = new Dictionary<User, MenuBar>();
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

        internal void AddMenuBar(MenuBar menubar) {
            this.Children.Add(menubar);
        }
    }
}
