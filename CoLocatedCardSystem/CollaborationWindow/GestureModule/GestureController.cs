using CoLocatedCardSystem.CollaborationWindow.TouchModule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Threading;

namespace CoLocatedCardSystem.CollaborationWindow.GestureModule
{
    class GestureController
    {
        InteractionControllers interactionControllers;
        GestureList list;
        TimeSpan period = TimeSpan.FromMilliseconds(50);
        ThreadPoolTimer periodicTimer;
        public GestureController(InteractionControllers itCtrlrs)
        {
            this.interactionControllers = itCtrlrs;
        }
        public void Init()
        {
            list = new GestureList();
        }

        public void Deinit()
        {
            if (periodicTimer != null)
            {
                periodicTimer.Cancel();
                periodicTimer = null;
            }
        }
        /// <summary>
        /// Add a gesture to the gesture list
        /// </summary>
        /// <param name="gesture"></param>
        public void AddGesture(Gesture gesture)
        {
            list.AddGesture(gesture);
        }
        /// <summary>
        /// Start the background thread to detect the gesture.
        /// </summary>
        public void StartGestureDetection()
        {
            if (periodicTimer == null)
            {
                periodicTimer = ThreadPoolTimer.CreatePeriodicTimer(async (source) =>
                {
                       await GestureThread();
                }, period);
            }
        }
        /// <summary>
        /// Start the gesture detection thread
        /// </summary>
        /// <returns></returns>
        private async Task GestureThread()
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                List<Touch> touchList = interactionControllers.GetAllTouches();
                UpdateGesture(touchList);
                DetectGesture(touchList);
            });
        }
        /// <summary>
        /// Update all gestures. Update the touches associated with the gesture.
        /// Create a touch list which only has the ones that not used by the existing gestures
        /// If the gesture is terminated or failed, remove it form the gesture list
        /// </summary>
        /// <returns></returns>
        private void UpdateGesture(List<Touch> touchList)
        {
            List<Gesture> gestureToRemove = new List<Gesture>();
            foreach (Gesture gesture in list.GetGesture())
            {
                gesture.UpdateAssociatedTouches(touchList);
                gesture.Update();
                if (gesture.Status == GestureStatus.FAILED ||
                    gesture.Status == GestureStatus.TERMINATED)
                {
                    gestureToRemove.Add(gesture);
                }
            }
            foreach (Gesture gesture in gestureToRemove)
            {
                list.RemoveGesture(gesture);
            }
        }
        /// <summary>
        /// Detect new gestures
        /// </summary>
        /// <returns></returns>
        private async void DetectGesture(List<Touch> touchList)
        {
            if (touchList != null && touchList.Count > 0)
            {
                await SortingGesture.Detect(touchList, interactionControllers);
            }
        }
        /// <summary>
        /// Remove gesture from list
        /// </summary>
        /// <param name="gesture"></param>
        internal void RemoveGesture(Gesture gesture)
        {
            list.RemoveGesture(gesture);
        }
    }
}
