using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    class Layer1:LayerBase
    {
        TextBlock titleTextBlock = new TextBlock();

        public object FontStretches { get; private set; }

        /// <summary>
        /// Initialize the card layers
        /// </summary>
        /// <param name="doc"></param>
        internal override async Task SetArticle(Document doc)
        {
            await base.SetArticle(doc);
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal,() =>
            {
                titleTextBlock.Text = doc.GetTitle();
                if (doc.GetTitle().Length > 50)
                {
                    titleTextBlock.FontSize = 15;

                }
                if (doc.GetTitle().Length > 100)
                {
                    titleTextBlock.FontSize = 12;
                }
            });
        }
        public Layer1(Card card) : base(card)
        {
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
            //Move the textblock - 1 / 2 width and -1 / 2 height to the center.
            MatrixTransform mtf = new MatrixTransform();
            mtf.Matrix = new Matrix(1, 0, 0, 1, -0.5 * attachedCard.Width, -0.5 * attachedCard.Height);
            this.RenderTransform = mtf;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                titleTextBlock.Width = attachedCard.Width;
                titleTextBlock.Height = attachedCard.Height;
                titleTextBlock.Foreground = new SolidColorBrush(Colors.Black);
                titleTextBlock.LineHeight = 1;
                titleTextBlock.TextWrapping = TextWrapping.Wrap;
                titleTextBlock.FontSize = 20;
                titleTextBlock.TextAlignment = TextAlignment.Center;
                titleTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
                titleTextBlock.VerticalAlignment = VerticalAlignment.Center;
                titleTextBlock.FontStretch = FontStretch.Normal;
                titleTextBlock.FontWeight = FontWeights.Bold;
                this.Children.Add(titleTextBlock);
            });
        }
    }
}
