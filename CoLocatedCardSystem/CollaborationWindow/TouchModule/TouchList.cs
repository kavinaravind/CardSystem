using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;

namespace CoLocatedCardSystem.CollaborationWindow.TouchModule
{
    class TouchList
    {
        Dictionary<uint, Touch> list = new Dictionary<uint, Touch>();
        /// <summary>
        /// Add a touch point to the list;
        /// </summary>
        /// <param name="position"></param>
        /// <param name="sender"></param>
        /// <param name="type"></param>
        internal void AddTouchPoint(PointerPoint position, object sender, Type type)
        {
            uint touchID = position.PointerId;
            if (!list.Keys.Contains(touchID))
            {
                Touch touch = new Touch();
                touch.Init(position, sender, type);
                list.Add(position.PointerId, touch);
            }
        }
        /// <summary>
        /// Update a touch point
        /// </summary>
        /// <param name="point"></param>
        internal void UpdateTouchPoint(PointerPoint point) {
            uint touchID = point.PointerId;
            if (list.Keys.Contains(touchID))
            {
                list[touchID].UpdateTouchPoint(point);
            }
        }
        /// <summary>
        /// Remove a Touchpoint from the list
        /// </summary>
        /// <param name="touchID"></param>
        /// <returns></returns>
        internal Touch RemoveTouchPoint(PointerPoint point) {
            uint touchID = point.PointerId;
            Touch removedTouch = null;
            if (list.Keys.Contains(touchID))
            {
                list[touchID].End(point);
                removedTouch = list[touchID];
                list.Remove(touchID);
            }
            return removedTouch;
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
