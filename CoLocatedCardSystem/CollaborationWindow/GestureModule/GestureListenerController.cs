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
        /// Return a listener object. All same gestures share one listener object
        /// </summary>
        /// <returns></returns>
        public GestureListener GetListener(Type listenerType) {
            return list.GetListener(listenerType);
        }
    }
}
