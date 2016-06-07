using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;

namespace CoLocatedCardSystem.CollaborationWindow.TouchModule
{
    class TouchController
    {
        TouchList list;
        /// <summary>
        /// Initialize the TouchController
        /// </summary>
        public void Init() {
            list = new TouchList();
        }
        /// <summary>
        /// Deinitialize the TouchController
        /// </summary>
        public void Deinit() {
            if (list != null) {
                list.Clear();
            }
        }
        /// <summary>
        /// Get a copy of all the touch points
        /// </summary>
        /// <returns></returns>
        public Touch[] GetTouchList() {
            return list.GetAllTouch();
        }
        /// <summary>
        /// Add a new touch to the touch list
        /// </summary>
        /// <param name="point"></param>
        /// <param name="sender"></param>
        /// <param name="type"></param>
        public void TouchDown(PointerPoint point, object sender, Type type) {

        }
        /// <summary>
        /// Update the touch points
        /// </summary>
        /// <param name="point"></param>
        public void TouchMove(PointerPoint point) {
        }
        /// <summary>
        /// Release the touch points
        /// </summary>
        /// <param name="point"></param>
        public void TouchUp(PointerPoint point) {

        }
    }
}
