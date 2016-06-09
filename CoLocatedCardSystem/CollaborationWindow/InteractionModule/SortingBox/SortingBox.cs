using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Input;
using Windows.UI.Input;
using Windows.UI.Core;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    public class SortingBox:Canvas
    {
        string sortingBoxID;
        string name;
        double sortingBoxScale;
        double rotation;

        User owner;
        Size sortingBoxSize;
        List<Card> cardList;
        Point position = new Point(0, 0);
        SortingBoxController sortingBoxController;
        Rectangle background; // Background rectangle

        public SortingBox(SortingBoxController sortingBoxController) {
            this.sortingBoxController = sortingBoxController;
        }
        public string SortingBoxID {
            get { return sortingBoxID; }
            set { sortingBoxID = value; }
        }

        public string SortingBoxName {
            get { return name; }
        }
        public double SortingBoxScale {
            get { return sortingBoxScale; }
        }

        public double Rotation {
            get { return rotation; }
        }

        public List<Card> CardList {
            get { return cardList; }
        }

        public Point Position {
            get { return position; }
        }

       /*
        * Initialize sorting box
        */
        internal void Init(string sortingBoxID, string name, User user) {
            this.sortingBoxID = sortingBoxID;
            this.name = name;
            SortingBoxInfo info = SortingBoxInfo.GetSortingBoxInfo(user);
            this.sortingBoxSize = info.SortingBoxSize;
            this.sortingBoxScale = info.SortingBoxScale;
            this.rotation = info.SortingBoxRotation;
            this.position = info.SortingBoxPosition;
            UpdateTransform();          
            this.owner = user;
            cardList = new List<Card>();

            //initialize the background rectangle
            background = new Rectangle();
            background.Width = sortingBoxSize.Width;
            background.Height = sortingBoxSize.Height;
            MatrixTransform mtf = new MatrixTransform();
            mtf.Matrix = new Matrix(1, 0, 0, 1, -0.5 * background.Width, -0.5 * background.Height);
            background.RenderTransform = mtf;
            background.Fill = new SolidColorBrush(info.SortingBoxColor);
            this.Children.Add(background);

            //Register the touch events
            this.PointerEntered += PointerDown;
            this.PointerPressed += PointerDown;
            this.PointerMoved += PointerMove;
            this.PointerCanceled += PointerUp;
            this.PointerReleased += PointerUp;
            this.PointerExited += PointerUp;
        }

       /*
        * Deinitialize sorting box
        */
        internal void Deinit() {
            background.PointerEntered -= PointerDown;
            background.PointerPressed -= PointerDown;
            background.PointerMoved -= PointerMove;
            background.PointerCanceled -= PointerUp;
            background.PointerReleased -= PointerUp;
            background.PointerExited -= PointerUp;
        }
        /// <summary>
        /// Move the sorting box by vector.
        /// </summary>
        /// <param name="vector"></param>
        public void Move(Point vector) {
            this.position.X += vector.X;
            this.position.Y += vector.Y;
            UpdateTransform();
        }
        /*
         * Move the box to the position
         */
        public void MoveTo(Point position) {
            this.position = position;
            UpdateTransform();
        }

       /*
        * Increase the box rotation by angle
        */
        public void Rotate(double angle) {
            this.rotation += angle;
            UpdateTransform();
        }

       /*
        * Scale the box to scale
        */
        public void Scale(double scale) {
            this.sortingBoxScale = scale;
            UpdateTransform();
        }

       /*
        * Move the card to the new position with new rotation and scale value
        */
        public void ApplyNewTransform(Point position, double rotation, double scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.sortingBoxScale = scale;
            UpdateTransform();
        }
        /*
         * Update the rendertransform and show the new states
         */
        private async void UpdateTransform() {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                ScaleTransform st = new ScaleTransform();
                st.ScaleX = sortingBoxScale;
                st.ScaleY = sortingBoxScale;
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

       /*
        * Call back method for pointer up
        */
        private void PointerUp(object sender, PointerRoutedEventArgs e) {
            PointerPoint point = e.GetCurrentPoint(this);
            sortingBoxController.PointerUp(point);
        }

       /*
        * Call back method for pointer move
        */
        private void PointerMove(object sender, PointerRoutedEventArgs e) {
            PointerPoint point = e.GetCurrentPoint(this);
            sortingBoxController.PointerMove(point);
        }

       /*
        * Call back method for pointer down
        */
        private void PointerDown(object sender, PointerRoutedEventArgs e) {
            PointerPoint point = e.GetCurrentPoint(this);
            sortingBoxController.PointerDown(point, this, typeof(Card));
        }

       /*
        * Change the background color of the box
        */
        public void setBackgroundColor(Color color) {
            background.Fill = new SolidColorBrush(color);
        }

       /*
        * Add a card to the sorting box
        */
        public void AddCard(Card card) {
            cardList.Add(card);
        }

       /*
        * Remove a card from the sorting box
        */
        public void RemoveCard(Card card) {
            if (cardList.Contains(card)) {
                cardList.Remove(card);
            }
        }

        /// <summary>
        /// Remove all cards from the sorting box
        /// </summary>
        public void Clear() {
            cardList.Clear();
        }

        /// <summary>
        ///  Check if a point is intersected with the sorting box.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool isIntersected(Point p) {
            return position.Equals(p);
        }
    }
}
