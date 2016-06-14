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
        PointerPoint currentPoint;//The PointerPoint associated with the touch                
        Point startPoint;//The position where the touch starts
        Point endPoint;//The position where the touch ends
        object sender;// The object which fire the touch
        Type type;// The type of the object
        DateTime startTime;//The start time stamp when the touch starts
        DateTime endTime;//The end time stamp when the touch ends
        public uint TouchID
        {
            get
            {
                return touchID;
            }
        }

        public PointerPoint CurrentPoint
        {
            get
            {
                return currentPoint;
            }
        }

        public Point StartPoint
        {
            get
            {
                return startPoint;
            }
        }

        public Point EndPoint
        {
            get
            {
                return endPoint;
            }
        }

        public object Sender
        {
            get
            {
                return sender;
            }
        }

        public Type Type
        {
            get
            {
                return type;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return startTime;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return endTime;
            }
        }

        /// <summary>
        /// Construct the touch point
        /// </summary>
        /// <param name="position"></param>
        /// <param name="sender"></param>
        /// <param name="type"></param>
        public void Init(PointerPoint position, object sender, Type type) {
            this.touchID = position.PointerId;
            this.sender = sender;
            this.type = type;
            this.currentPoint = position;
            this.startPoint = position.Position;
            this.startTime = DateTime.Now;
        }
        /// <summary>
        /// Generate a copy of the touch List
        /// </summary>
        /// <returns></returns>
        internal Touch Copy()
        {
            Touch newTouch = new Touch();
            newTouch.touchID = this.touchID;
            newTouch.currentPoint = this.currentPoint;
            newTouch.startPoint = this.startPoint;
            newTouch.endPoint = this.endPoint;
            newTouch.sender = this.sender;
            newTouch.type = this.type;
            newTouch.startTime = this.startTime;
            newTouch.endTime = this.endTime;
            return newTouch;
        }

        /// <summary>
        /// Update a touch point
        /// </summary>
        /// <param name="point"></param>
        public void UpdateTouchPoint(PointerPoint point) {

        }
        /// <summary>
        /// Call this method when the finger leave the screen.
        /// </summary>
        /// <param name="position"></param>
        public Touch End(PointerPoint position)
        {
            this.endPoint = position.Position;
            this.endTime = DateTime.Now;
            return this;
        }
    }
}
