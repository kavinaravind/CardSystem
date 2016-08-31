using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    class Tile : Button
    {
        Color color;
        Token token;
        double textSize;
        internal void Init(Token token, double textSize)
        {
            this.token = token;
            this.textSize = textSize;
            InitUI();
        }

        private void InitUI()
        {
            this.Content = token.OriginalWord;
            this.Background = new SolidColorBrush(Colors.Gray);
            this.FontSize = textSize;
            this.Padding = new Thickness(0);
            this.VerticalContentAlignment = VerticalAlignment.Top;
            this.BorderThickness = new Thickness(0.5);

            this.PointerPressed += Tile_PointerPressed;
            this.PointerReleased += Tile_PointerReleased;
        }

        private void Tile_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void Tile_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.Yellow);
        }
    }
}
