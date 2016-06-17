using CoLocatedCardSystem.CollaborationWindow.InteractionModule;
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
        public override void ContinueGesture(object sender, GestureEventArgs e)
        {
            base.ContinueGesture(sender, e);
            SemanticCard card = (SemanticCard)e.Senders[0];
            card.Rotate(10);//for debug
        }
        public override void TerminateGesture(object sender, GestureEventArgs e)
        {
            base.TerminateGesture(sender, e);
            SemanticCard card = (SemanticCard)e.Senders[0];
            SortingBox box = (SortingBox)e.Senders[1];
            box.AddCard(card);
            System.Diagnostics.Debug.WriteLine("Card Sorted: "+card.Document.GetTitle());
        }
    }
}
