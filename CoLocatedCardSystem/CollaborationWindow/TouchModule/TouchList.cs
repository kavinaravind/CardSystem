using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;

namespace CoLocatedCardSystem.CollaborationWindow.TouchModule
{
    class TouchList
    {
        Dictionary<int, Touch> list = new Dictionary<int, Touch>();
        /// <summary>
        /// Add a touch point to the list;
        /// </summary>
        /// <param name="position"></param>
        /// <param name="sender"></param>
        /// <param name="type"></param>
        internal void AddTouchPoint(PointerPoint position, object sender, Type type) {

        }
        /// <summary>
        /// Remove a Touchpoint from the list
        /// </summary>
        /// <param name="touchID"></param>
        /// <returns></returns>
        internal Touch RemoveTouchPoint(int touchID) {
            return null;
        }
        /// <summary>
        /// Delete all the touches from the list.
        /// </summary>
        internal void Clear() {
            list.Clear();
        }
        /// <summary>
        /// Get a copy of all touches in the touch list
        /// </summary>
        /// <returns></returns>
        internal Touch[] GetAllTouch() {
            return list.Values.ToArray();
        }
    }
}
