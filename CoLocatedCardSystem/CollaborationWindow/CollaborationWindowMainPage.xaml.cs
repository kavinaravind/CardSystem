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
        ViewControllers viewControllers;
        InteractionControllers interactionControllers;
        public CollaborationWindowMainPage()
        {
            this.InitializeComponent();
            Init();
        }

        public void Init()
        {
            Screen.WIDTH = (int)ApplicationView.GetForCurrentView().VisibleBounds.Width;
            Screen.HEIGHT = (int)ApplicationView.GetForCurrentView().VisibleBounds.Height;
            this.Width = Screen.WIDTH;
            this.Height = Screen.HEIGHT;
            Container.Width = this.Width;
            Container.Height = this.Height;
            ApplicationView.PreferredLaunchViewSize = new Size(this.Width, this.Height);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
            viewControllers = new ViewControllers();
            interactionControllers = new InteractionControllers();
            viewControllers.Init(Screen.WIDTH, Screen.HEIGHT,interactionControllers);
            interactionControllers.Init(viewControllers);

            Container.Children.Add(viewControllers.GetBaseLayer());
            Container.Children.Add(viewControllers.GetCardLayer());
        }
        public void Deinit()
        {
            viewControllers.Deinit();
            Container.Children.Remove(viewControllers.GetBaseLayer());
            interactionControllers.Deinit();
        }
    }
}
