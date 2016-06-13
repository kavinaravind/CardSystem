using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
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
            Transform(info.Position,info.Rotate,info.Scale,info.Size,this);
            LoadUI(info);
            
        }
        /// <summary>
        /// Load the buttons and other ui elements on the menu
        /// </summary>
        /// <param name="info"></param>
        private void LoadUI(MenuBarInfo info)
        {
            Button keyboardButton = new Button();
            keyboardButton.Content = "Create a Box";
            Transform(info.KeyboardButtonInfo.Position, 0, 1, info.KeyboardButtonInfo.Size, keyboardButton);
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/menu_bg.png"));
            this.Background = brush;
            this.Children.Add(keyboardButton);
        }
        /// <summary>
        /// Update the render transform
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        /// <param name="element"></param>
        private void Transform(Point position, double rotation, double scale, Size size, FrameworkElement element) {
            element.Width = size.Width;
            element.Height = size.Height;
            ScaleTransform st = new ScaleTransform();
            st.ScaleX = scale;
            st.ScaleY = scale;
            RotateTransform rt = new RotateTransform();
            rt.Angle = rotation;
            TranslateTransform tt = new TranslateTransform();
            tt.X = position.X;
            tt.Y = position.Y;
            TransformGroup transGroup = new TransformGroup();
            transGroup.Children.Add(st);
            transGroup.Children.Add(rt);
            transGroup.Children.Add(tt);
            element.RenderTransform = transGroup;
        }
    }
}
