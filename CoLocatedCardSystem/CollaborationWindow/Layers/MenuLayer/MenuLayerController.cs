using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CoLocatedCardSystem.CollaborationWindow.Layers
{
    class MenuLayerController
    {
        MenuLayer menuLayer;
        CentralControllers controllers;
        Dictionary<User, MenuBar> list = new Dictionary<User, MenuBar>();
        internal MenuLayer MenuLayer
        {
            get
            {
                return menuLayer;
            }
        }
        public MenuLayerController(CentralControllers ctrls) {
            this.controllers = ctrls;
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
            menuLayer.Deinit();
        }
        /// <summary>
        /// Ask the interaction module to create a sorting box
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="content"></param>
        internal void CreateSortingBox(User owner, string content)
        {
            if (content.Length > 0)
            {
                controllers.SortingBoxController.CreateSortingBox(owner, content);
            }
        }
        /// <summary>
        /// Get all menu bars
        /// </summary>
        /// <returns></returns>
        internal MenuBar[] GetAllMenuBars()
        {
            return list.Values.ToArray();
        }
        /// <summary>
        /// Pass the touch poitn to the touch module
        /// </summary>
        /// <param name="localPoint"></param>
        /// <param name="globalPoint"></param>
        /// <param name="sender"></param>
        /// <param name="type"></param>
        internal void PointerDown(PointerPoint localPoint, PointerPoint globalPoint, object sender, Type type)
        {
            controllers.TouchController.TouchDown(localPoint, globalPoint, sender, type);
        }
        /// <summary>
        /// update the touch point
        /// </summary>
        /// <param name="localPoint"></param>
        /// <param name="globalPoint"></param>
        internal void PointerMove(PointerPoint localPoint, PointerPoint globalPoint)
        {
            controllers.TouchController.TouchMove(localPoint, globalPoint);
        }
        /// <summary>
        /// End the touch Point
        /// </summary>
        /// <param name="localPoint"></param>
        /// <param name="globalPoint"></param>
        internal void PointerUp(PointerPoint localPoint, PointerPoint globalPoint)
        {
            controllers.TouchController.TouchUp(localPoint, globalPoint);
        }
    }
}
