using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.GestureModule
{
    class GestureListenerController
    {
        InteractionControllers interactionControllers;
        GestureListenerList list;
        
        public GestureListenerController(InteractionControllers itcCtrlers) {
            this.interactionControllers = itcCtrlers;
        }
        /// <summary>
        /// Initialize the gesture listener controller
        /// </summary>
        public void Init() {
            list = new GestureListenerList(this);
        }
        /// <summary>
        /// Return a sorting listener object.
        /// </summary>
        /// <returns></returns>
        public SortingListener GetSortingListener() {
            return list.GetListener(typeof(SortingListener)) as SortingListener;
        }
    }
}
