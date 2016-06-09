using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
using CoLocatedCardSystem.CollaborationWindow.GestureModule;
using CoLocatedCardSystem.CollaborationWindow.InteractionModule;
using CoLocatedCardSystem.CollaborationWindow.TouchModule;
using System;
using System.Threading.Tasks;
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
            cardController = new CardController(this);
            sortingBoxController = new SortingBoxController(this);
            touchController = new TouchController(this);

            Document[] docs = await documentController.Init(FilePath.NewsArticle);//Load the document
            Card[] cards = await cardController.Init(docs);
            await viewControllers.LoadCardsToCardLayer(cards);
            
            touchController.Init();
            sortingBoxController.Init();
            sortingBoxController.CreateSortingBox("alex", User.ALEX);

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
        /// <summary>
        /// Move the card to the top
        /// </summary>
        /// <param name="card"></param>
        internal void MoveCardToTop(Card card)
        {
            viewControllers.MoveCardToTop(card);
        }
    }
}
