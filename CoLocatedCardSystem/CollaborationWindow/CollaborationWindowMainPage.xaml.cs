using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CoLocatedCardSystem.CollaborationWindow
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CollaborationWindowMainPage : Page
    {
        CentralControllers controllers;
        public CollaborationWindowMainPage()
        {
            this.InitializeComponent();
            Init();
        }

        public void Init()
        {
            Screen.WIDTH = (int)ApplicationView.GetForCurrentView().VisibleBounds.Width;
            Screen.HEIGHT = (int)ApplicationView.GetForCurrentView().VisibleBounds.Height;
            System.Diagnostics.Debug.WriteLine(Screen.WIDTH + " " + Screen.HEIGHT);
            this.Width = Screen.WIDTH;
            this.Height = Screen.HEIGHT;
            Container.Width = this.Width;
            Container.Height = this.Height;
            ApplicationView.PreferredLaunchViewSize = new Size(this.Width, this.Height);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
            controllers = new CentralControllers();
            controllers.Init(Screen.WIDTH, Screen.HEIGHT);

            Container.Children.Add(controllers.BaseLayerController.BaseLayer);
            Container.Children.Add(controllers.CardLayerController.CardLayer);
            Container.Children.Add(controllers.SortingBoxLayerController.SortingBoxLayer);
            Container.Children.Add(controllers.MenuLayerController.MenuLayer);
        }
        public void Deinit()
        {
            controllers.Deinit();
            Container.Children.Remove(controllers.BaseLayerController.BaseLayer);
            Container.Children.Remove(controllers.CardLayerController.CardLayer);
            Container.Children.Remove(controllers.SortingBoxLayerController.SortingBoxLayer);
            Container.Children.Remove(controllers.MenuLayerController.MenuLayer);
        }
    }
}
