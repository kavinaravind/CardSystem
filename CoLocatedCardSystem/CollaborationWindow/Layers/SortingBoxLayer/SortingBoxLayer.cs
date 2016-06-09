using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoLocatedCardSystem.CollaborationWindow.InteractionModule;
using Windows.UI.Xaml.Controls;
using Windows.UI.Core;

namespace CoLocatedCardSystem.CollaborationWindow.Layers
{
    class SortingBoxLayer : Canvas
    {
        private SortingBoxLayerController sortingBoxLayerController;

        public SortingBoxLayer(SortingBoxLayerController sortingBoxLayerController) {
            this.sortingBoxLayerController = sortingBoxLayerController;
        }

        internal void Init(int width, int height) {
            this.Width = width;
            this.Height = height;
        }

        internal void Deinit() {
            this.Children.Clear();
        }

        internal async Task AddBox(SortingBox box) {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                this.Children.Add(box);
            });
        }
    }
}
