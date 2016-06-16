using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
                MenuBar bar = new MenuBar(this);
                bar.Init(user);
                list.Add(user, bar);
                menuLayer.AddMenuBar(bar);
            }
        }
        /// <summary>
        /// Destroy the menu layer
        /// </summary>
        public void Deinit() {
            foreach (MenuBar bar in list.Values)
            {
                bar.Deinit();
            }
            list.Clear();
        }
        /// <summary>
        /// Ask the interaction module to create a sorting box
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="content"></param>
        internal void CreateSortingBox(User owner, string content)
        {
            viewControllers.CreateSortingBox(owner, content);
        }
        /// <summary>
        /// Get all menu bars
        /// </summary>
        /// <returns></returns>
        internal MenuBar[] GetAllMenuBars()
        {
            return list.Values.ToArray();
        }
    }
}
