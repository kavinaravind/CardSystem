using System;
using System.Threading.Tasks;
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
        Point position = new Point(0, 0);
        double cardScale = 1;
        double rotation = 0;
        Rectangle background = null;
        int marginWidth = 10;
        CardController cardController;
        Size maxSize = new Size(600, 450);//Max size a card can be zoomed.
        Size minSize = new Size(80, 60);//Mim size a card can be zoomed

        public Point Position
        {
            get
            {
                return position;
            }
        }

        public double CardScale
        {
            get
            {
                return cardScale;
            }
        }

        public double Rotation
        {
            get
            {
                return rotation;
            }
        }

        public Card(CardController cardController) {
            this.cardController = cardController;
        }

        public string CardID
        {
            get { return cardID; }
            set { cardID = value; }
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
        internal virtual void Init(string cardID, User user)
        {
            this.cardID = cardID;
            CardInfo info = CardInfo.GetCardInfo(user);
            this.Width = info.CardSize.Width;
            this.Height = info.CardSize.Height;
            this.position = info.CardPosition;
            this.cardScale = info.CardScale;
            this.rotation = info.CardRotation;
            UpdateTransform();
            background = new Rectangle();
            background.Width = this.Width + marginWidth * 2;
            background.Height = this.Height + marginWidth * 2;
            //Move the backgroud rectangle -1/2 width and -1/2 height to the center.
            MatrixTransform mtf = new MatrixTransform();
            mtf.Matrix = new Matrix(1, 0, 0, 1, -0.5 * background.Width, -0.5 * background.Height);
            background.RenderTransform = mtf;
            background.Fill = new SolidColorBrush(info.CardColor);
            //Register the touch events
            this.Children.Add(background);
            this.PointerEntered += PointerDown;
            this.PointerPressed += PointerDown;
            this.PointerMoved += PointerMove;
            this.PointerCanceled += PointerUp;
            this.PointerReleased += PointerUp;
            this.PointerExited += PointerUp;
            //Manipulation
            this.ManipulationMode = ManipulationModes.All;
            this.ManipulationStarting += Card_ManipulationStarting;
            this.ManipulationDelta += Card_ManipulationDelta;
            ////For debug
            //Random rand = new Random(DateTime.Now.Millisecond);
            //Move(new Point(rand.Next(1000), rand.Next(800)));
        }

        internal void Deinit()
        {
            this.PointerEntered -= PointerDown;
            this.PointerPressed -= PointerDown;
            this.PointerMoved -= PointerMove;
            this.PointerCanceled -= PointerUp;
            this.PointerReleased -= PointerUp;
            this.PointerExited -= PointerUp;
            this.ManipulationStarting -= Card_ManipulationStarting;
            this.ManipulationDelta -= Card_ManipulationDelta;
        }
        /// <summary>
        /// Move the card by the vector 
        /// </summary>
        /// <param name="point"></param>
        public void Move(Point vector)
        {
            this.position.X += vector.X;
            this.position.Y += vector.Y;
            UpdateTransform();
        }
        /// <summary>
        /// Move the card to the position
        /// </summary>
        /// <param name="position"></param>
        public void MoveTo(Point position)
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
            this.cardScale = scale;
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
            this.cardScale = scale;
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
                 st.ScaleX = cardScale;
                 st.ScaleY = cardScale;
                 RotateTransform rt = new RotateTransform();
                 rt.Angle = Rotation;
                 TranslateTransform tt = new TranslateTransform();
                 tt.X = Position.X;
                 tt.Y = Position.Y;
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
        protected virtual void PointerDown(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint point = e.GetCurrentPoint(this);
            cardController.PointerDown(point, this, typeof(Card));
        }
        /// <summary>
        /// Call back method for Pointer move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void PointerMove(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint point = e.GetCurrentPoint(this);
            cardController.PointerMove(point);
        }
        /// <summary>
        /// Call back method for pointer up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void PointerUp(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint point = e.GetCurrentPoint(this);
            cardController.PointerUp(point);
        }
        /// <summary>
        /// Manipulate the card. Move if the manipulation is valid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Card_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (IsValideManipulation(e.Delta.Translation, e.Delta.Rotation, e.Delta.Scale)) {
                this.position.X += e.Delta.Translation.X;
                this.position.Y += e.Delta.Translation.Y;
                this.rotation += e.Delta.Rotation;
                this.cardScale *= e.Delta.Scale;
                UpdateTransform();
            }
        }

       

        /// <summary>
        /// Check if the manipulation is valid. 
        /// Cancel the manipulation if the card larger or smaller than the bound, or moved out of the screen.
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="rotat"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        private bool IsValideManipulation(Point trans, double rotat, double scale)
        {
            bool isValid = true;
            if (scale * this.cardScale * this.Width >= maxSize.Width ||
                scale * this.cardScale * this.Height >= maxSize.Height ||
                scale * this.cardScale * this.Width <= minSize.Width ||
                scale * this.cardScale * this.Height <= minSize.Height)
            {
                isValid = false;
            }
            if (position.X + trans.X > Screen.WIDTH ||
                position.X + trans.X < 0 ||
                position.Y + trans.Y > Screen.HEIGHT ||
                position.Y + trans.Y < 0)
            {
                isValid = false;
            }
            return isValid;
        }
        /// <summary>
        /// Update the z index of the focused the card. Put it on the top of other cards.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Card_ManipulationStarting(object sender, ManipulationStartingRoutedEventArgs e)
        {
            cardController.MoveCardToTop(this);
        }
    }
}
