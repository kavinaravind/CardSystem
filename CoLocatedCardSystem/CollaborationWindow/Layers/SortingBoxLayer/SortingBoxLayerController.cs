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

        internal async Task LoadBoxes(SortingBox[] boxes) {
            foreach (SortingBox box in boxes) {
                await sortingBoxLayer.AddBox(box);
            }
        }
    }
}
