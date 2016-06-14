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
using Windows.UI.Text;
using Windows.UI.Xaml;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    public class SortingBox : Canvas
    {
        string sortingBoxID;
        string name;
        double sortingBoxScale;
        double rotation;

        User owner;
        List<Card> cardList;
        Point position = new Point(0, 0);
        SortingBoxController sortingBoxController;
        Rectangle background; // Background rectangle
        TextBox sortingTextBox;
        Size maxSize = new Size(600, 450);
        Size minSize = new Size(80, 60);


        public SortingBox(SortingBoxController sortingBoxController)
        {
            this.sortingBoxController = sortingBoxController;
        }
        public string SortingBoxID
        {
            get { return sortingBoxID; }
            set { sortingBoxID = value; }
        }

        public string SortingBoxName
        {
            get { return name; }
        }
        public double SortingBoxScale
        {
            get { return sortingBoxScale; }
        }

        public double Rotation
        {
            get { return rotation; }
        }

        public List<Card> CardList
        {
            get { return cardList; }
        }

        public Point Position
        {
            get { return position; }
        }

        /// <summary>
        /// Initialize sorting box
        /// </summary>
        /// <param name="sortingBoxID"></param>
        /// <param name="name"></param>
        /// <param name="user"></param>
        internal void Init(string sortingBoxID, string name, User user)
        {
            this.sortingBoxID = sortingBoxID;
            this.name = name;
            SortingBoxInfo info = SortingBoxInfo.GetSortingBoxInfo(user);
            this.Width = info.SortingBoxSize.Width;
            this.Height = info.SortingBoxSize.Height;
            this.sortingBoxScale = info.SortingBoxScale;
            this.rotation = info.SortingBoxRotation;
            this.position = info.SortingBoxPosition;
            UpdateTransform();
            this.owner = user;
            cardList = new List<Card>();

            //initialize the background rectangle
            background = new Rectangle();
            background.Width = info.SortingBoxSize.Width;
            background.Height = info.SortingBoxSize.Height;
            MatrixTransform mtf = new MatrixTransform();
            mtf.Matrix = new Matrix(1, 0, 0, 1, -0.5 * background.Width, -0.5 * background.Height);
            background.RenderTransform = mtf;
            background.Fill = new SolidColorBrush(Colors.Transparent);
            background.Stroke = new SolidColorBrush(Colors.Gray);
            background.StrokeThickness = 5;
            this.Children.Add(background);

            sortingTextBox = new TextBox();
            sortingTextBox.Width = info.SortingBoxSize.Width;
            sortingTextBox.Height = info.SortingBoxSize.Height;
            sortingTextBox.RenderTransform = mtf;
            sortingTextBox.Background = new SolidColorBrush(Colors.Transparent);
            sortingTextBox.Foreground = new SolidColorBrush(Colors.Transparent);
            sortingTextBox.Text = "Sorting Box";
            sortingTextBox.IsReadOnly = true;
            sortingTextBox.FontFamily = new FontFamily("Comic Sans MS");
            sortingTextBox.FontSize = 24;
            sortingTextBox.FontWeight = FontWeights.Bold;
            sortingTextBox.TextAlignment = TextAlignment.Center;
            sortingTextBox.VerticalAlignment = VerticalAlignment.Center;
            this.Children.Add(sortingTextBox);

            Canvas.SetZIndex(background, 2);
            Canvas.SetZIndex(sortingTextBox, 1);

            //Register the touch events
            this.PointerEntered += PointerDown;
            this.PointerPressed += PointerDown;
            this.PointerMoved += PointerMove;
            this.PointerCanceled += PointerUp;
            this.PointerReleased += PointerUp;
            this.PointerExited += PointerUp;

            this.ManipulationMode = ManipulationModes.All;
            this.ManipulationStarting += SortingBox_ManipulationStarting;
            this.ManipulationDelta += SortingBox_ManipulationDelta;
        }

        /// <summary>
        /// Deinitialize sorting box
        /// </summary>
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
        /// Move the sorting box by vector.
        /// </summary>
        /// <param name="vector"></param>
        public void Move(Point vector)
        {
            this.position.X += vector.X;
            this.position.Y += vector.Y;
            UpdateTransform();
        }

        /// <summary>
        /// Move the box to the position
        /// </summary>
        /// <param name="position"></param>
        public void MoveTo(Point position)
        {
            this.position = position;
            UpdateTransform();
        }

        /// <summary>
        /// Increase the box rotation by angle
        /// </summary>
        /// <param name="angle"></param>
        public void Rotate(double angle)
        {
            this.rotation += angle;
            UpdateTransform();
        }

        /// <summary>
        /// Scale the box to scale
        /// </summary>
        /// <param name="scale"></param>
        public void Scale(double scale)
        {
            this.sortingBoxScale = scale;
            UpdateTransform();
        }

        /// <summary>
        /// Move the card to the new position with new rotation and scale value
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        public void ApplyNewTransform(Point position, double rotation, double scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.sortingBoxScale = scale;
            UpdateTransform();
        }

        /// <summary>
        /// Update the rendertransform and show the new states
        /// </summary>
        private async void UpdateTransform()
        {
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

        /// <summary>
        /// Call back method for pointer up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointerUp(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint point = e.GetCurrentPoint(this);
            sortingBoxController.PointerUp(point);
        }

        /// <summary>
        /// Call back method for pointer move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointerMove(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint point = e.GetCurrentPoint(this);
            sortingBoxController.PointerMove(point);
        }

        /// <summary>
        /// Call back method for pointer down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointerDown(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint point = e.GetCurrentPoint(this);
            sortingBoxController.PointerDown(point, this, typeof(SortingBox));
        }

        /// <summary>
        /// Change the background color of the box
        /// </summary>
        /// <param name="color"></param>
        public void setBackgroundColor(Color color)
        {
            background.Fill = new SolidColorBrush(color);
        }

        /// <summary>
        /// Add a card to the sorting box
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(Card card)
        {
            cardList.Add(card);
        }

        /// <summary>
        /// Remove a card from the sorting box
        /// </summary>
        /// <param name="card"></param>
        public void RemoveCard(Card card)
        {
            if (cardList.Contains(card))
            {
                cardList.Remove(card);
            }
        }

        /// <summary>
        /// Remove all cards from the sorting box
        /// </summary>
        public void Clear()
        {
            cardList.Clear();
        }

        /// <summary>
        ///  Check if a point is intersected with the sorting box.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<bool> IsIntersected(Point p)
        {
            double distance = 0;
            double radius = 0;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                distance = Math.Sqrt(Math.Pow(p.X - position.X, 2) + Math.Pow(p.Y - position.Y, 2));
                radius = this.Width * this.sortingBoxScale;
            });
            return distance < radius;
        }

        /// <summary>
        /// Manipulate the sorting box. Move if the manipulation is valid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void SortingBox_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (IsValideManipulation(e.Delta.Translation, e.Delta.Rotation, e.Delta.Scale))
            {
                this.position.X += e.Delta.Translation.X;
                this.position.Y += e.Delta.Translation.Y;
                this.rotation += e.Delta.Rotation;
                this.sortingBoxScale *= e.Delta.Scale;
                UpdateTransform();
            }
        }

        /// <summary>
        /// Check if the manipulation is valid. 
        /// Cancel the manipulation if the sorting box is larger or smaller than the bound, or moved out of the screen.
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="rotat"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        private bool IsValideManipulation(Point trans, double rotat, double scale)
        {
            bool isValid = true;
            if (scale * this.sortingBoxScale * this.Width >= maxSize.Width ||
                scale * this.sortingBoxScale * this.Height >= maxSize.Height ||
                scale * this.sortingBoxScale * this.Width <= minSize.Width ||
                scale * this.sortingBoxScale * this.Height <= minSize.Height)
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
        /// Update the z index of the focused the sorting box. Put it on the top.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void SortingBox_ManipulationStarting(object sender, ManipulationStartingRoutedEventArgs e)
        {
            sortingBoxController.MoveSortingBoxToTop(this);
        }
    }
}