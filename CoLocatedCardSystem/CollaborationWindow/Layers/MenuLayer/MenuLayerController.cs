using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.Layers
{
    class MenuLayerController
    {
        MenuLayer menuLayer;
        ViewControllers viewControllers;
        Dictionary<User, MenuBar> list = new Dictionary<User, MenuBar>();
        public MenuLayerController(ViewControllers vctrls) {
            this.viewControllers = vctrls;
        }

        internal MenuLayer MenuLayer
        {
            get
            {
                return menuLayer;
            }
        }

        /// <summary>
        /// Initialize the menu controller and the menu layer.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Init(int width, int height) {
            menuLayer = new MenuLayer(this);
            menuLayer.Init(width, height);
            foreach (User user in UserInfo.GetLiveUsers()) {
                MenuBar bar = new MenuBar();
                bar.Init(user);
                list.Add(user, new MenuBar());
                menuLayer.AddMenuBar(bar);
            }
        }
    }
}
