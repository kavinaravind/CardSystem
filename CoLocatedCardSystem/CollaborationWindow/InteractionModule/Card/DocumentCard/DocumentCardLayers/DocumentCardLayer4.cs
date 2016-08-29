using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
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
    class DocumentCardLayer4 : DocumentCardLayerBase
    {

        TextBlock titleTextBlock = new TextBlock();
        TextBlock authorTextBlock = new TextBlock();
        TextBlock timeTextBlock = new TextBlock();
        TextBlock contentTextBlock = new TextBlock();
        public DocumentCardLayer4(Card card) : base(card)
        {
        }

        internal override async Task SetArticle(Document doc)
        {
            await base.SetArticle(doc);
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                titleTextBlock.Text = doc.GetTitle();
                authorTextBlock.Text = doc.GetAuthor();
                timeTextBlock.Text = doc.GetTime().ToString();
                contentTextBlock.Text = doc.GetContent();
            });
        }
        /// <summary>
        /// Initialize the layer
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
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
                Grid layerGrid = new Grid();
                layerGrid.Width = attachedCard.Width;
                layerGrid.Height = attachedCard.Height;
                layerGrid.HorizontalAlignment = HorizontalAlignment.Left;
                layerGrid.VerticalAlignment = VerticalAlignment.Top;
                // Create Columns
                ColumnDefinition gridCol1 = new ColumnDefinition();
                layerGrid.ColumnDefinitions.Add(gridCol1);

                // Create Rows
                RowDefinition gridRow1 = new RowDefinition();
                gridRow1.Height = new GridLength(10,GridUnitType.Star);
                RowDefinition gridRow2 = new RowDefinition();
                gridRow2.Height = new GridLength(10, GridUnitType.Star);
                RowDefinition gridRow3 = new RowDefinition();
                gridRow3.Height = new GridLength(10, GridUnitType.Star);
                RowDefinition gridRow4 = new RowDefinition();
                gridRow4.Height = new GridLength(70, GridUnitType.Star);

                layerGrid.RowDefinitions.Add(gridRow1);
                layerGrid.RowDefinitions.Add(gridRow2);
                layerGrid.RowDefinitions.Add(gridRow3);
                layerGrid.RowDefinitions.Add(gridRow4);

                ScrollViewer titleSV = new ScrollViewer();
                titleSV.Width = attachedCard.Width;
                titleSV.Height = attachedCard.Height * 0.1;
                titleSV.HorizontalAlignment = HorizontalAlignment.Center;
                titleSV.VerticalAlignment = VerticalAlignment.Center;
                titleTextBlock.Width = attachedCard.Width;
                titleTextBlock.Height = double.NaN;
                titleTextBlock.Foreground = new SolidColorBrush(Colors.Black);
                titleTextBlock.LineHeight = 1;
                titleTextBlock.TextWrapping = TextWrapping.Wrap;
                titleTextBlock.FontSize = 5;
                titleTextBlock.TextAlignment = TextAlignment.Left;
                titleTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
                titleTextBlock.VerticalAlignment = VerticalAlignment.Center;
                titleTextBlock.FontStretch = FontStretch.Normal;
                titleSV.Content = titleTextBlock;
                Grid.SetColumn(titleSV, 0);
                Grid.SetRow(titleSV, 0);
                layerGrid.Children.Add(titleSV);

                authorTextBlock.Width = attachedCard.Width;
                authorTextBlock.Height = double.NaN;
                authorTextBlock.Foreground = new SolidColorBrush(Colors.Black);
                authorTextBlock.LineHeight = 1;
                authorTextBlock.TextWrapping = TextWrapping.Wrap;
                authorTextBlock.FontSize = 4;
                authorTextBlock.TextAlignment = TextAlignment.Left;
                authorTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
                authorTextBlock.VerticalAlignment = VerticalAlignment.Center;
                authorTextBlock.FontStretch = FontStretch.Normal;
                Grid.SetColumn(authorTextBlock, 0);
                Grid.SetRow(authorTextBlock, 1);
                layerGrid.Children.Add(authorTextBlock);

                timeTextBlock.Width = attachedCard.Width;
                timeTextBlock.Height = double.NaN;
                timeTextBlock.Foreground = new SolidColorBrush(Colors.Black);
                timeTextBlock.LineHeight = 1;
                timeTextBlock.TextWrapping = TextWrapping.Wrap;
                timeTextBlock.FontSize = 4;
                timeTextBlock.TextAlignment = TextAlignment.Left;
                timeTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
                timeTextBlock.VerticalAlignment = VerticalAlignment.Center;
                timeTextBlock.FontStretch = FontStretch.Normal;
                Grid.SetColumn(timeTextBlock, 0);
                Grid.SetRow(timeTextBlock, 2);
                layerGrid.Children.Add(timeTextBlock);

                ScrollViewer contentSV = new ScrollViewer();
                contentSV.Width = attachedCard.Width;
                contentSV.Height = attachedCard.Height*0.7;
                contentSV.HorizontalAlignment = HorizontalAlignment.Center;
                contentSV.VerticalAlignment = VerticalAlignment.Center;
                contentTextBlock.Width = attachedCard.Width;
                contentTextBlock.Foreground = new SolidColorBrush(Colors.Black);
                contentTextBlock.LineHeight = 1;
                contentTextBlock.TextWrapping = TextWrapping.Wrap;
                contentTextBlock.FontSize = 3;
                contentTextBlock.TextAlignment = TextAlignment.Left;
                contentTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
                contentTextBlock.VerticalAlignment = VerticalAlignment.Center;
                contentTextBlock.FontStretch = FontStretch.Normal;
                contentSV.Content = contentTextBlock;
                Grid.SetColumn(contentSV, 0);
                Grid.SetRow(contentSV, 3);
                layerGrid.Children.Add(contentSV);
                this.Children.Add(layerGrid);
            });
        }
    }
}
