using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    /// <summary>
    /// Base card, basic form of the card
    /// </summary>
    public class Card : Canvas
    {
        string cardID = "";
        Size cardSize = new Size(120, 90);
        protected Point position = new Point(0, 0);
        protected double scale = 1;
        protected double rotation = 0;
        Rectangle background = null;
        int marginWidth = 10;
        CardController cardController;
        public Card(CardController cardController) {
            this.cardController = cardController;
        }
        /// <summary>
        /// Initialize a card
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <param name="rotation"></param>
        internal virtual void Init(string cardID, UserInfo info)
        {
            this.cardID = cardID;
            this.cardSize = info.CardSize;
            this.position = info.CardPosition;
            this.scale = info.CardScale;
            this.rotation = info.CardRotation;
            UpdateTransform();
            background = new Rectangle();
            background.Width = this.cardSize.Width + marginWidth * 2;
            background.Height = this.cardSize.Height + marginWidth * 2;
            //Move the backgroud rectangle -1/2 width and -1/2 height to the center.
            MatrixTransform mtf = new MatrixTransform();
            mtf.Matrix = new Matrix(1, 0, 0, 1, -0.5 * background.Width, -0.5 * background.Height);
            background.RenderTransform = mtf;
            background.Fill = new SolidColorBrush(Colors.Black);//For visibility debug
            //Register the touch events
            this.Children.Add(background);
            this.PointerEntered += PointerDown;
            this.PointerPressed += PointerDown;
            this.PointerMoved += PointerMove;
            this.PointerCanceled += PointerUp;
            this.PointerReleased += PointerUp;
            this.PointerExited += PointerUp;
        }
        internal void Deinit()
        {
            background.PointerEntered -= PointerDown;
            background.PointerPressed -= PointerDown;
            background.PointerMoved -= PointerMove;
            background.PointerCanceled -= PointerUp;
            background.PointerReleased -= PointerUp;
            background.PointerExited -= PointerUp;
        }
        /// <summary>
        /// Move the card to the position
        /// </summary>
        /// <param name="position"></param>
        public void Move(Point position)
        {
            this.position = position;
            UpdateTransform();
        }
        /// <summary>
        /// Rotate the card by "angle" degree. Add to the current rotation
        /// </summary>
        /// <param name="angle"></param>
        public void Rotate(double angle)
        {
            this.rotation += angle;
            UpdateTransform();
        }
        /// <summary>
        /// Scale the card to the "scale"
        /// </summary>
        /// <param name="scale"></param>
        public void Scale(double scale)
        {
            this.scale = scale;
            UpdateTransform();
        }
        /// <summary>
        /// Move the card to the new position with new rotation and scale value
        /// </summary>
        /// <param name="point"></param>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        public void ApplyNewTransform(Point position, double rotation, double scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
            UpdateTransform();
        }
        /// <summary>
        /// Update the transform group
        /// </summary>
        private async void UpdateTransform()
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
             {
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

                 this.RenderTransform = transGroup;
             });
        }
        /// <summary>
        /// Call back method for Pointer down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointerDown(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint point = e.GetCurrentPoint(this);
            cardController.PointerDown(point, this, typeof(Card));
        }
        /// <summary>
        /// Call back method for Pointer move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointerMove(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint point = e.GetCurrentPoint(this);
            cardController.PointerMove(point);
        }
        /// <summary>
        /// Call back method for pointer up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointerUp(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint point = e.GetCurrentPoint(this);
            cardController.PointerUp(point);
        }
    }
}
