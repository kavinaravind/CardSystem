using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;

namespace CoLocatedCardSystem.CollaborationWindow.TouchModule
{
    class TouchController
    {
        InteractionControllers interactionControllers;
        TouchList list;
        bool isMouseEnabled = true;
        bool isPenEnabled = true;
        public TouchController(InteractionControllers intrCtlrs) {
            this.interactionControllers = intrCtlrs;
        }
        /// <summary>
        /// Initialize the TouchController
        /// </summary>
        public void Init() {
            list = new TouchList();
        }
        /// <summary>
        /// Deinitialize the TouchController
        /// </summary>
        public void Deinit() {
            if (list != null) {
                list.Clear();
            }
        }
        /// <summary>
        /// Get a copy of all the touch points
        /// </summary>
        /// <returns></returns>
        public Touch[] GetTouchList() {
            return list.GetAllTouch();
        }
        /// <summary>
        /// Add a new touch to the touch list. Two parameters control the pointertye. 
        /// Touch will always be captured. 
        /// Mouse and Pen can be configured.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="sender"></param>
        /// <param name="type"></param>
        public void TouchDown(PointerPoint point, object sender, Type type)
        {
            switch (point.PointerDevice.PointerDeviceType)
            {
                case Windows.Devices.Input.PointerDeviceType.Touch:
                    list.AddTouchPoint(point, sender, type);
                    break;
                case Windows.Devices.Input.PointerDeviceType.Mouse:
                    if (isMouseEnabled)
                        list.AddTouchPoint(point, sender, type);
                    break;
                case Windows.Devices.Input.PointerDeviceType.Pen:
                    if (isPenEnabled)
                        list.AddTouchPoint(point, sender, type);
                    break;
            }
        }
        /// <summary>
        /// Update the touch points
        /// </summary>
        /// <param name="point"></param>
        public void TouchMove(PointerPoint point)
        {
            switch (point.PointerDevice.PointerDeviceType)
            {
                case Windows.Devices.Input.PointerDeviceType.Touch:
                    list.UpdateTouchPoint(point);
                    break;
                case Windows.Devices.Input.PointerDeviceType.Mouse:
                    if (isMouseEnabled)
                        list.UpdateTouchPoint(point);
                    break;
                case Windows.Devices.Input.PointerDeviceType.Pen:
                    if (isPenEnabled)
                        list.UpdateTouchPoint(point);
                    break;
            }
        }
        /// <summary>
        /// Release the touch points
        /// </summary>
        /// <param name="point"></param>
        public void TouchUp(PointerPoint point) {
            switch (point.PointerDevice.PointerDeviceType)
            {
                case Windows.Devices.Input.PointerDeviceType.Touch:
                    list.RemoveTouchPoint(point);
                    break;
                case Windows.Devices.Input.PointerDeviceType.Mouse:
                    if (isMouseEnabled)
                        list.RemoveTouchPoint(point);
                    break;
                case Windows.Devices.Input.PointerDeviceType.Pen:
                    if (isPenEnabled)
                        list.RemoveTouchPoint(point);
                    break;
            }
        }
    }
}
