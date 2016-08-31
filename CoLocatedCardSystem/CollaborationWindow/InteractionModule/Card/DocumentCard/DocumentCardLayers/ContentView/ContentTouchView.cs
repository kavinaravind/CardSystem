using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    class ContentTouchView : StackPanel
    {
        List<Tile> list = new List<Tile>();
        Document document;
        /// <summary>
        /// Initialize the view.
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="width"></param>
        internal async void Init(Document doc, double width)
        {
            this.document = doc;
            this.Width = width;
            await InitUI(doc);
        }
        /// <summary>
        /// Initialize the UI of the content touch view. the words are aligned in a horizontal
        /// Stackpanel, and horizontal Stackpanels are filled in to a vertical Stackpanel. Key
        /// words are showed in Tile, other words are in TextBlock.
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private async Task InitUI(Document doc)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                this.Orientation = Orientation.Vertical;
                double currentHight = -1;
                double currentWidth = 0;
                this.BorderThickness = new Thickness(0);
                double textSize = 4;
                StackPanel horiPanel = new StackPanel();
                horiPanel.Orientation = Orientation.Horizontal;
                foreach (Token token in doc.ProcessedDocument.List)
                {
                    Size boxSize = UIHelper.GetBoundingSize(token.OriginalWord, textSize);
                    if (currentHight == -1) {
                        currentHight = boxSize.Height;
                        horiPanel = new StackPanel();
                        horiPanel.Width = this.Width;
                        horiPanel.Height = boxSize.Height;
                        horiPanel.Orientation = Orientation.Horizontal;
                        this.Children.Add(horiPanel);
                    }
                    currentWidth += boxSize.Width;
                    if (currentWidth > this.Width) {
                        horiPanel = new StackPanel();
                        horiPanel.Width = this.Width;
                        horiPanel.Height = boxSize.Height;
                        horiPanel.Orientation = Orientation.Horizontal;
                        currentWidth = boxSize.Width;
                        currentHight += boxSize.Height;
                        this.Children.Add(horiPanel);
                    }
                    if (token.WordType == WordType.REGULAR)
                    {
                        Tile tile = new Tile();
                        tile.Init(token, textSize);
                        list.Add(tile);
                        horiPanel.Children.Add(tile);
                    }
                    else {
                        TextBlock block = new TextBlock();
                        block.Text = token.OriginalWord;
                        block.FontSize = textSize;
                        block.Padding = new Thickness(0);
                        block.Width = boxSize.Width;
                        block.Height = boxSize.Height;
                        horiPanel.Children.Add(block);
                    }
                }
                this.Height = currentHight;
            });
        }
    }
}
