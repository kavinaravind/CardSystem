using CoLocatedCardSystem.CollaborationWindow.TouchModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.GestureModule
{
    class GestureEventArgs:EventArgs
    {
        private Touch[] touches;
        private object[] senders;

        public Touch[] Touches
        {
            get
            {
                return touches;
            }

            set
            {
                touches = value;
            }
        }

        public object[] Senders
        {
            get
            {
                return senders;
            }

            set
            {
                senders = value;
            }
        }
    }
}
