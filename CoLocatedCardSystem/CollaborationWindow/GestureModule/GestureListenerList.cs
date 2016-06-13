using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.GestureModule
{
    class GestureListenerList
    {
        Dictionary<Type, GestureListener> list = new Dictionary<Type, GestureListener>();
        internal GestureListenerList(GestureListenerController controller) {
            list.Add(typeof(SortingListener), new SortingListener(controller));
        }
        /// <summary>
        /// Get the listener instance in the list
        /// </summary>
        /// <param name="listenerType"></param>
        /// <returns></returns>
        internal GestureListener GetListener(Type listenerType) {
            return list[listenerType];
        }
    }
}
