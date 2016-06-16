using CoLocatedCardSystem.CollaborationWindow.InteractionModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.GestureModule
{
    class DeletingBoxListener : GestureListener
    {
        public DeletingBoxListener(GestureListenerController gCtrlers) : base(gCtrlers)
        {
        }
        public override void TerminateGesture(object sender, GestureEventArgs e)
        {
            base.TerminateGesture(sender, e);
            SortingBox box = e.Senders[0] as SortingBox;
            gestureListenerController.RemoveSortingBox(box);
        }
    }
}
