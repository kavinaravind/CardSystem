using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
using CoLocatedCardSystem.CollaborationWindow.GestureModule;
using CoLocatedCardSystem.CollaborationWindow.InteractionModule;
using CoLocatedCardSystem.CollaborationWindow.TouchModule;
using System;
using Windows.UI.Input;

namespace CoLocatedCardSystem.CollaborationWindow
{
    /// <summary>
    /// A central controller for all other controllers
    /// </summary>
    public class InteractionControllers
    {
        ViewControllers viewControllers;
        DocumentController documentController;
        CardController cardController;
        SortingBoxController sortingBoxController;
        TouchController touchController;
        GestureController gestureController;
        GestureListenerController listenerController;
        /// <summary>
        /// Initialize all documents
        /// </summary>
        public async void Init(ViewControllers viewControllers) {
            this.viewControllers = viewControllers;
            documentController = new DocumentController(this);
            await documentController.Init(FilePath.NewsArticle);//Load the document
            touchController = new TouchController(this);
            touchController.Init();
        }
        /// <summary>
        /// Destroy the interaction listener
        /// </summary>
        internal void Deinit()
        {
            documentController.Deinit();
        }
        /// <summary>
        /// Add a touch point to the touch module
        /// </summary>
        /// <param name="point"></param>
        /// <param name="sender"></param>
        /// <param name="type"></param>
        internal void OnTouchDown(PointerPoint point, object sender, Type type) {
            touchController.TouchDown(point, sender, type);
        }
        /// <summary>
        /// Update a touch point
        /// </summary>
        /// <param name="point"></param>
        internal void OnTouchMove(PointerPoint point) {
            touchController.TouchMove(point);
        }
        /// <summary>
        /// End a touch point.
        /// </summary>
        /// <param name="point"></param>
        internal void OnTouchUp(PointerPoint point) {
            touchController.TouchUp(point);
        }
    }
}
