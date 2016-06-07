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

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    public class SortingBox:Canvas
    {
        string sortingBoxID;
        string name;
        Size sortingBoxSize;
        Point position;
        double scale;
        double rotation;
        Rectangle background;//Background rectangle
        List<Card> cardList;
        User owner;
        /// <summary>
        /// Initialize sorting box
        /// </summary>
        internal void Init(string sortingBoxID, string name, UserInfo info) {
            this.sortingBoxID = sortingBoxID;
            this.name = name;
            this.sortingBoxSize = info.SortingBoxSize;
            this.scale = info.SortingBoxScale;
            this.rotation = info.SortingBoxRotation;
            this.position = info.SortingBoxPosition;            
            this.owner = info.User;
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
        /// <summary>
        /// Move the box to the position
        /// </summary>
        /// <param name="position"></param>
        public void Move(Point position) {
            this.position = position;
            UpdateTransform();
        }
        /// <summary>
        /// Increase the box rotation by angle
        /// </summary>
        /// <param name="angle"></param>
        public void Rotate(double angle) {
            this.rotation += angle;
            UpdateTransform();
        }
        /// <summary>
        /// Scale the box to scale
        /// </summary>
        /// <param name="scale"></param>
        public void Scale(double scale)
        {
            this.scale = scale;
            UpdateTransform();
        }
        /// <summary>
        /// Update the rendertransform and show the new states
        /// </summary>
        private void UpdateTransform()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Call back method for pointer up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointerUp(object sender, PointerRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Call back method for pointer move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointerMove(object sender, PointerRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Call back method for pointer down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointerDown(object sender, PointerRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Change the background color of the box
        /// </summary>
        /// <param name="color"></param>
        public void setBackgroundColor(Color color) {
        }
        /// <summary>
        /// Add a card to the sorting box
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(Card card) {
        }
        /// <summary>
        /// Remove a card from the sorting box
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public Card RemoveCard(Card card) {
            return null;
        }
        /// <summary>
        /// Remove all cards from the sorting box
        /// </summary>
        public void Clear() {

        }
        /// <summary>
        /// Check if a point is intersected with the sorting box.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool isIntersected(Point p) {
            return false;
        }
    }
}
