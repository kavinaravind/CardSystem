using CoLocatedCardSystem.CollaborationWindow.TableModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    class ItemCardLayer2 : ItemCardLayerBase
    {
        StackPanel panel = new StackPanel();
        TextBlock contentTextBlock = new TextBlock();
        
        public ItemCardLayer2(Card card) : base(card)
        {

        }
        internal override async Task SetItem(Item item)
        {
            await base.SetItem(item);
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                String str = item.GetAll();
                String[] items = str.Split('\n');

                foreach (String itemName in items)
                {
                    Button button = new Button();
                    button.Name = itemName;
                    panel.Children.Add(button);
                }

                contentTextBlock.Text = item.GetAll();
                if (item.GetAll().Length > 50)
                {
                    contentTextBlock.FontSize = 6;

                }
                if (item.GetAll().Length > 100)
                {
                    contentTextBlock.FontSize = 4;
                }
            });
        }
        internal override async void Init()
        {
            this.Width = attachedCard.Width;
            this.Height = attachedCard.Height;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                //Move the textblock - 1 / 2 width and -1 / 2 height to the center.
                UIHelper.InitializeUI(
                    new Point(-0.5 * attachedCard.Width, -0.5 * attachedCard.Height),
                    0,
                    1,
                    new Size(this.Width, this.Height),
                    this);
                contentTextBlock.Width = attachedCard.Width;
                contentTextBlock.Foreground = new SolidColorBrush(Colors.Black);
                contentTextBlock.LineHeight = 1;
                contentTextBlock.TextWrapping = TextWrapping.Wrap;
                contentTextBlock.FontSize = 8;
                contentTextBlock.TextAlignment = TextAlignment.Left;
                contentTextBlock.FontStretch = FontStretch.Normal;
                contentTextBlock.FontWeight = FontWeights.Bold;
                panel.Children.Add(contentTextBlock);
                ScrollViewer sv = new ScrollViewer();
                sv.Width = attachedCard.Width;
                sv.Height = attachedCard.Height;
                sv.HorizontalAlignment = HorizontalAlignment.Center;
                sv.VerticalAlignment = VerticalAlignment.Center;
                sv.Content = panel;
                this.Children.Add(sv);
            });
        }
    }
}
