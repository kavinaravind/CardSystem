using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace CoLocatedCardSystem.CollaborationWindow.Layers
{
    /// <summary>
    /// A layer to show all the active cards
    /// </summary>
    class CardLayer : Canvas
    {
        CardLayerController cardLayerController;
        Rectangle rect = new Rectangle();//For test purpose

        public CardLayer(CardLayerController clctrl)
        {
            this.cardLayerController = clctrl;
        }
        internal void Init(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            #region test
            rect.Width = 200;
            rect.Height = 100;
            rect.Fill = new SolidColorBrush(Colors.Red);
            ScaleTransform st = new ScaleTransform();
            st.ScaleX = 1;
            st.ScaleY = 1;
            RotateTransform rt = new RotateTransform();
            rt.Angle = 0;
            TranslateTransform tt = new TranslateTransform();
            tt.X = 300;
            tt.Y = 200;
            TransformGroup tg = new TransformGroup();
            tg.Children.Add(st);
            tg.Children.Add(rt);
            tg.Children.Add(tt);
            rect.RenderTransform = tg;
            this.Children.Add(rect);
            #endregion
        }
        internal void Deinit()
        {
        }
    }
}
