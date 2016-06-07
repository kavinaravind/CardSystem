using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace CoLocatedCardSystem.CollaborationWindow.Layers
{
    /// <summary>
    /// The invisible layer stay at the bottom
    /// </summary>
    class BaseLayer : Canvas
    {
        /// <summary>
        /// Control the BaseLayer, initialized with the layer
        /// </summary>
        BaseLayerController baseLayerController;
        Rectangle baseRect;
        internal BaseLayerController BaseLayerController
        {
            get
            {
                return baseLayerController;
            }

            set
            {
                baseLayerController = value;
            }
        }
        public BaseLayer(BaseLayerController baseLyrCtrl)
        {
            this.baseLayerController = baseLyrCtrl;
        }
        /// <summary>
        /// Initialize the view and add listener
        /// </summary>
        internal void Init(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            baseRect = new Rectangle();
            baseRect.Width = this.Width;
            baseRect.Height = this.Height;
            baseRect.Fill = new SolidColorBrush(Colors.Wheat);//For visibility
            this.Children.Add(baseRect);
            baseRect.PointerEntered += PointerDown;
            baseRect.PointerPressed += PointerDown;
            baseRect.PointerMoved += PointerMove;
            baseRect.PointerCanceled += PointerUp;
            baseRect.PointerReleased += PointerUp;
            baseRect.PointerExited += PointerUp;
        }
        /// <summary>
        /// Destroy the view and remove listener
        /// </summary>
        internal void Deinit()
        {
            baseRect.PointerEntered -= PointerDown;
            baseRect.PointerPressed -= PointerDown;
            baseRect.PointerMoved -= PointerMove;
            baseRect.PointerCanceled -= PointerUp;
            baseRect.PointerReleased -= PointerUp;
            baseRect.PointerExited -= PointerUp;
        }
        /// <summary>
        /// Call back method for Pointer down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointerDown(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint point = e.GetCurrentPoint(this);
            baseLayerController.PointerDown(point);
        }
        /// <summary>
        /// Call back method for Pointer move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointerMove(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint point = e.GetCurrentPoint(this);
            baseLayerController.PointerMove(point);
        }
        /// <summary>
        /// Call back method for pointer up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointerUp(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint point = e.GetCurrentPoint(this);
            baseLayerController.PointerUp(point);
        }
    }
}
