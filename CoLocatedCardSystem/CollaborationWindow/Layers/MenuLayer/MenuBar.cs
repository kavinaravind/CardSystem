using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace CoLocatedCardSystem.CollaborationWindow.Layers
{
    class MenuBar:Canvas
    {
        internal void Init(User user)
        {
            MenuBarInfo info = MenuBarInfo.GetMenuBarInfo(user);
            this.Width = info.Size.Width;
            this.Height = info.Size.Height;
            ScaleTransform st = new ScaleTransform();
            st.ScaleX = info.Scale;
            st.ScaleY = info.Scale;
            RotateTransform rt = new RotateTransform();
            rt.Angle = info.Rotate;
            TranslateTransform tt = new TranslateTransform();
            tt.X = info.Position.X;
            tt.Y = info.Position.Y;
            TransformGroup transGroup = new TransformGroup();
            transGroup.Children.Add(st);
            transGroup.Children.Add(rt);
            transGroup.Children.Add(tt);
            this.RenderTransform = transGroup;
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/menu_bg.png"));
            this.Background = brush;
        }
    }
}
