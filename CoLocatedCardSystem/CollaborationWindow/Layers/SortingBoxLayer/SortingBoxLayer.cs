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

        public SortingBoxLayer(SortingBoxLayerController sortingBoxLayerController)
        {
            this.sortingBoxLayerController = sortingBoxLayerController;
        }
        /// <summary>
        /// Initialize the sorting box layer
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        internal void Init(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        /// <summary>
        /// Destroy the sorting box layer
        /// </summary>
        internal void Deinit()
        {
            this.Children.Clear();
        }
        /// <summary>
        /// Add a sorting box to the layer
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        internal async Task AddBox(SortingBox box)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                this.Children.Add(box);
            });
        }


        /// <summary>
        /// Set the z index of the card
        /// </summary>
        /// <param name="card"></param>
        /// <param name="zindex"></param>
        internal void SetZIndex(SortingBox box, int zindex)
        {
            Canvas.SetZIndex(box, zindex);
        }
    }
}
