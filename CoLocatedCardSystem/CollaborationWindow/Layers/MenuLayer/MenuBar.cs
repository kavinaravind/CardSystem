using System;
using System.Linq;
using System.Threading.Tasks;
using VirtualKeyboard;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace CoLocatedCardSystem.CollaborationWindow.Layers
{
    class MenuBar : Canvas
    {
        OnScreenKeyBoard virtualKeyboard;
        TextBox textbox;
        Button createSortingBoxButton;
        MenuLayerController menuLayerController;
        User owner;
        Button deleteButton;
        public MenuBar(MenuLayerController controller)
        {
            this.menuLayerController = controller;
        }
        /// <summary>
        /// Initialize the menubar
        /// </summary>
        /// <param name="user"></param>
        internal void Init(User user)
        {
            MenuBarInfo info = MenuBarInfo.GetMenuBarInfo(user);
            this.owner = user;
            UIHelper.InitializeUI(info.Position, info.Rotate, info.Scale, info.Size, this);
            LoadUI(info);
        }

        /// <summary>
        /// Destroy the menubar.
        /// </summary>
        internal void Deinit()
        {
            createSortingBoxButton.PointerEntered -= PointerDown;
            createSortingBoxButton.PointerPressed -= PointerDown;
            createSortingBoxButton.PointerMoved -= PointerMove;
            createSortingBoxButton.PointerExited -= PointerUp;
            createSortingBoxButton.PointerReleased -= PointerUp;
            createSortingBoxButton.Click -= KeyboardButton_Click;
            virtualKeyboard.PointerEntered -= PointerDown;
            virtualKeyboard.PointerPressed -= PointerDown;
            virtualKeyboard.PointerMoved -= PointerMove;
            virtualKeyboard.PointerExited -= PointerUp;
            virtualKeyboard.PointerReleased -= PointerUp;
            virtualKeyboard.Disable();
            virtualKeyboard = null;
            deleteButton.Click -= DeleteButton_Click;
            deleteButton.PointerEntered -= PointerDown;
            deleteButton.PointerPressed -= PointerDown;
            deleteButton.PointerMoved -= PointerMove;
            deleteButton.PointerExited -= PointerUp;
            deleteButton.PointerReleased -= PointerUp;
        }
        /// <summary>
        /// Load the buttons and other ui elements on the menu
        /// </summary>
        /// <param name="info"></param>
        private void LoadUI(MenuBarInfo info)
        {
            //Initialize the button to show the keyboard
            createSortingBoxButton = new Button();
            createSortingBoxButton.Content = "Create a Box";
            createSortingBoxButton.Click += KeyboardButton_Click;
            createSortingBoxButton.PointerEntered += PointerDown;
            createSortingBoxButton.PointerPressed += PointerDown;
            createSortingBoxButton.PointerMoved += PointerMove;
            createSortingBoxButton.PointerExited += PointerUp;
            createSortingBoxButton.PointerReleased += PointerUp;
            UIHelper.InitializeUI(info.KeyboardButtonInfo.Position, 0, 1, info.KeyboardButtonInfo.Size, createSortingBoxButton);
            //Initialize the text block
            textbox = new TextBox();
            textbox.AcceptsReturn = true;
            UIHelper.InitializeUI(info.InputTextBoxInfo.Position, 0, 1, info.InputTextBoxInfo.Size, textbox);
            textbox.Visibility = Visibility.Collapsed;
            textbox.TextChanged += Textbox_TextChanged;
            //Initialize the keyboard to create the sorting box
            virtualKeyboard = new OnScreenKeyBoard();
            virtualKeyboard.InitialLayout = KeyboardLayouts.English;
            virtualKeyboard.Visibility = Visibility.Collapsed;
            virtualKeyboard.PointerEntered += PointerDown;
            virtualKeyboard.PointerPressed += PointerDown;
            virtualKeyboard.PointerMoved += PointerMove;
            virtualKeyboard.PointerExited += PointerUp;
            virtualKeyboard.PointerReleased += PointerUp;
            UIHelper.InitializeUI(info.KeyboardInfo.Position, 0, 1, info.KeyboardInfo.Size, virtualKeyboard);
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
            //Initialize the menubar
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/menu_bg.png"));
            this.Background = brush;
            this.Children.Add(createSortingBoxButton);
            this.Children.Add(virtualKeyboard);
            this.Children.Add(textbox);
            this.Children.Add(deleteButton);
        }

        /// <summary>
        /// Detects when the an enter is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if (textbox.Text.Length > 0 && textbox.Text.Last<char>().Equals('\n'))
                {
                    virtualKeyboard.Visibility = Visibility.Collapsed;
                    textbox.Visibility = Visibility.Collapsed;
                    virtualKeyboard.Disable();
                    createSortingBoxButton.Content = "Create a Box";
                    string text = textbox.Text;
                    CreateSortingBox(text.TrimEnd());
                    textbox.Text = "";
                }
            });
        }

        /// <summary>
        /// Configure the keyboard and the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void KeyboardButton_Click(object sender, RoutedEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if (virtualKeyboard.Visibility == Visibility.Visible)
                {
                    virtualKeyboard.Visibility = Visibility.Collapsed;
                    textbox.Visibility = Visibility.Collapsed;
                    virtualKeyboard.Disable();
                    createSortingBoxButton.Content = "Create a Box";
                    textbox.Text = "";
                }
                else
                {
                    textbox.Visibility = Visibility.Visible;
                    virtualKeyboard.Visibility = Visibility.Visible;
                    virtualKeyboard.Enable(textbox);
                    createSortingBoxButton.Content = "Close";
                }
            });
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
        /// Ask the interaction module to add a sorting box
        /// </summary>
        /// <param name="content"></param>
        private void CreateSortingBox(string content)
        {
            menuLayerController.CreateSortingBox(owner, content);
        }
        /// <summary>
        /// Check if the point is intersect with delete button
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        internal async Task<bool> IsIntersectWithDelete(Point position)
        {
            bool isIntersect = false;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                isIntersect = Coordination.IsIntersect(position, deleteButton, false);
            });
            return isIntersect;
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
            if (sender == createSortingBoxButton)
            {
                type = typeof(Button);
            }
            else if (sender == virtualKeyboard)
            {
                type = typeof(OnScreenKeyBoard);
            }
            else if (sender == deleteButton) {
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
