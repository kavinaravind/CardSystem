using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace CoLocatedCardSystem.CollaborationWindow.Layers
{
    class DeleteButton : Canvas
    {
        MenuLayerController menuLayerController;
        Button deleteButton;
        TextBlock notificationBlock;
        Grid grid;

        public DeleteButton(MenuLayerController controller)
        {
            this.menuLayerController = controller;
        }

        /// <summary>
        /// Load the buttons and other ui elements on the menu
        /// </summary>
        /// <param name="info"></param>
        private void LoadUI(MenuBarInfo info)
        {
            //Initialize the Deletebutton
            deleteButton = new Button();
            deleteButton.Content = "Delete";
            deleteButton.Click += DeleteButton_Click;
            deleteButton.PointerEntered += PointerDown;
            deleteButton.PointerPressed += PointerDown;
            deleteButton.PointerMoved += PointerMove;
            deleteButton.PointerExited += PointerUp;
            deleteButton.PointerReleased += PointerUp;
            UIHelper.InitializeUI(info.DeleteButtonInfo.Position, 0, 1, info.DeleteButtonInfo.Size, deleteButton);

            //Initialize the notificationBlock + Grid
            grid = new Grid();
            notificationBlock = new TextBlock();
            grid.Background = new SolidColorBrush(Colors.White);
            notificationBlock.Text = "The Sorting Box will be deleted when it's dragged into this.";
            notificationBlock.TextWrapping = TextWrapping.Wrap;
            Point position = new Point(250, -60);
            UIHelper.InitializeUI(position, 0, 1, info.DeleteButtonInfo.Size, grid);
            grid.Children.Add(notificationBlock);
            grid.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Sets the delete notification to appear if the user hovers over the delete button
        /// </summary>
        public void setGridVisibility()
        {
            if (grid.Visibility.Equals(Visibility.Visible))
            {
                grid.Visibility = Visibility.Collapsed;
            }
            else
            {
                grid.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Callback method when the delete an item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Call back method for Pointer down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointerDown(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint localPoint = e.GetCurrentPoint(this);
            PointerPoint globalPoint = e.GetCurrentPoint(Coordination.Baselayer);
            Type type = null;
            if (sender == deleteButton)
            {
                type = typeof(Button);
            }
            menuLayerController.PointerDown(localPoint, globalPoint, sender, type);
        }
        /// <summary>
        /// Call back method for Pointer move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointerMove(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint localPoint = e.GetCurrentPoint(this);
            PointerPoint globalPoint = e.GetCurrentPoint(Coordination.Baselayer);
            menuLayerController.PointerMove(localPoint, globalPoint);
        }

        /// <summary>
        /// Call back method for pointer up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointerUp(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint localPoint = e.GetCurrentPoint(this);
            PointerPoint globalPoint = e.GetCurrentPoint(Coordination.Baselayer);
            menuLayerController.PointerUp(localPoint, globalPoint);
        }
    }
}
