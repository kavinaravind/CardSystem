using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace CoLocatedCardSystem.CollaborationWindow.GestureModule
{
    class SortingListener : GestureListener
    {
        public SortingListener(GestureListenerController gCtrlers) : base(gCtrlers)
        {

        }

        public override void TerminateGesture(object sender, GestureEventArgs e)
        {
            base.TerminateGesture(sender, e);
            System.Diagnostics.Debug.WriteLine("Sort");

        }
    }
}
