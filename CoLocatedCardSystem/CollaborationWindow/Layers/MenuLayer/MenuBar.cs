using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCD.Controls.Keyboard;
using Windows.Foundation;
using Windows.System;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace CoLocatedCardSystem.CollaborationWindow.Layers
{
    class MenuBar:Canvas
    {
        OnScreenKeyBoard virtualKeyboard;
        TextBox textbox;
        Button createSortingBoxButton;
        MenuLayerController menuLayerController;
        User owner;
        public MenuBar(MenuLayerController controller) {
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
            Transform(info.Position, info.Rotate, info.Scale, info.Size, this);
            LoadUI(info);
        }
        /// <summary>
        /// Destroy the menubar.
        /// </summary>
        internal void Deinit() {
            createSortingBoxButton.Click -= KeyboardButton_Click;
            virtualKeyboard.Disable();
            virtualKeyboard = null;
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
            Transform(info.KeyboardButtonInfo.Position, 0, 1, info.KeyboardButtonInfo.Size, createSortingBoxButton);
            //Initialize the text block
            textbox = new TextBox();
            textbox.AcceptsReturn = true;
            Transform(info.InputTextBoxInfo.Position, 0, 1, info.InputTextBoxInfo.Size, textbox);
            textbox.Visibility = Visibility.Collapsed;
            textbox.TextChanged += Textbox_TextChanged;            
            //Initialize the keyboard to create the sorting box
            createSortingBoxButton.Click += KeyboardButton_Click;
            virtualKeyboard = new OnScreenKeyBoard();
            virtualKeyboard.InitialLayout = KeyboardLayouts.English;
            virtualKeyboard.Visibility = Visibility.Collapsed;
            Transform(info.KeyboardInfo.Position, 0, 1, info.KeyboardInfo.Size, virtualKeyboard);
            //Initialize the menubar
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/menu_bg.png"));
            this.Background = brush;
            this.Children.Add(createSortingBoxButton);
            this.Children.Add(virtualKeyboard);
            this.Children.Add(textbox);
        }
        /// <summary>
        /// Detects when the an enter is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textbox.Text.Last<char>().Equals('\n')) {
                virtualKeyboard.Visibility = Visibility.Collapsed;
                textbox.Visibility = Visibility.Collapsed;
                virtualKeyboard.Disable();
                createSortingBoxButton.Content = "Create a Box";
                CreateABox(textbox.Text.TrimEnd());
                textbox.Text = "";
            }
        }

        /// <summary>
        /// Configure the keyboard and the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyboardButton_Click(object sender, RoutedEventArgs e)
        {
            if (virtualKeyboard.Visibility == Visibility.Visible)
            {
                virtualKeyboard.Visibility = Visibility.Collapsed;
                textbox.Visibility = Visibility.Collapsed;
                virtualKeyboard.Disable();
                createSortingBoxButton.Content = "Create a Box";
            }
            else
            {
                textbox.Visibility = Visibility.Visible;
                virtualKeyboard.Visibility = Visibility.Visible;
                virtualKeyboard.Enable(textbox);
                createSortingBoxButton.Content = "Close";
            }
        }
        /// <summary>
        /// Ask the interaction module to add a sorting box
        /// </summary>
        /// <param name="content"></param>
        private void CreateABox(string content) {
            if (content.Length > 0)
            {
                menuLayerController.CreateSortingBox(owner, content);
            }
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
