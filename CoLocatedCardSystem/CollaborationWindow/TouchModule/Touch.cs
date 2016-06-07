using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Input;

namespace CoLocatedCardSystem.CollaborationWindow.TouchModule
{
    public class Touch
    {
        uint touchID;
        PointerPoint currentPoint;                
        Point startPoint;//The position where the touch starts
        Point endPoint;//The position where the touch ends
        object sender;// The object which fire the touch
        Type type;// The type of the object
        DateTime startTime;//The start time stamp when the touch starts
        DateTime endTime;//The end time stamp when the touch ends

        /// <summary>
        /// Construct the touch point
        /// </summary>
        /// <param name="position"></param>
        /// <param name="sender"></param>
        /// <param name="type"></param>
        public Touch(PointerPoint position, object sender, Type type) {
            this.touchID = position.PointerId;
            this.sender = sender;
            this.type = type;
            this.currentPoint = position;
            this.startPoint = position.Position;
            this.startTime = DateTime.Now;
        }
        /// <summary>
        /// Call this method when the finger leave the screen.
        /// </summary>
        /// <param name="position"></param>
        public void End(PointerPoint position)
        {
            this.endPoint = position.Position;
            this.endTime = DateTime.Now;
        }
    }
}
