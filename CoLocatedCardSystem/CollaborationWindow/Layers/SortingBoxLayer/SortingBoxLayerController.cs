using CoLocatedCardSystem.CollaborationWindow.InteractionModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.Layers
{
    class SortingBoxLayerController
    {
        SortingBoxLayer sortingBoxLayer;
        private ViewControllers viewControllers;
        Dictionary<SortingBox, int> zIndexList = new Dictionary<SortingBox, int>();

        internal SortingBoxLayer SortingBoxLayer {
            get { return sortingBoxLayer; }
        }

        public SortingBoxLayerController(ViewControllers vctrl) {
            this.viewControllers = vctrl;
        }

        public void Init(int width, int height) {
            sortingBoxLayer = new SortingBoxLayer(this);
            sortingBoxLayer.Init(width, height);
        }

        public void Deinit() {
            sortingBoxLayer.Deinit();
        }
        /// <summary>
        /// Add sorting boxes to the sorting box layer.
        /// </summary>
        /// <param name="boxes"></param>
        /// <returns></returns>
        internal async Task LoadBoxes(SortingBox[] boxes) {
            int index = zIndexList.Count();
            foreach (SortingBox box in boxes) {
                await sortingBoxLayer.AddBox(box);
                zIndexList.Add(box, index++);
                sortingBoxLayer.SetZIndex(box, zIndexList[box]);
            }
        }

        /// <summary>
        /// Update the card zindex in the cardlayer
        /// </summary>
        /// <param name="card"></param>
        internal void MoveSortingBoxToTop(SortingBox box)
        {
            if (zIndexList.Keys.Contains(box))
            {
                int currentIndex = zIndexList[box];
                foreach (SortingBox bx in sortingBoxLayer.Children)
                {
                    if (zIndexList[bx] > currentIndex)
                    {
                        zIndexList[bx]--;
                        sortingBoxLayer.SetZIndex(bx, zIndexList[bx]);
                    }
                }
                zIndexList[box] = zIndexList.Count - 1;
                sortingBoxLayer.SetZIndex(box, zIndexList[box]);
            }
        }
    }
}
