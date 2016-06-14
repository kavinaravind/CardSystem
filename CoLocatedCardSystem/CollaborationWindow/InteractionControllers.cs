using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
using CoLocatedCardSystem.CollaborationWindow.GestureModule;
using CoLocatedCardSystem.CollaborationWindow.InteractionModule;
using CoLocatedCardSystem.CollaborationWindow.TouchModule;
using System;
using System.Threading.Tasks;
using Windows.UI.Input;
using System.Collections.Generic;

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

        public ViewControllers ViewControllers
        {
            get
            {
                return viewControllers;
            }
        }

        internal DocumentController DocumentController
        {
            get
            {
                return documentController;
            }
        }

        public CardController CardController
        {
            get
            {
                return cardController;
            }
        }

        public SortingBoxController SortingBoxController
        {
            get
            {
                return sortingBoxController;
            }
        }

        internal TouchController TouchController
        {
            get
            {
                return touchController;
            }
        }
        /// <summary>
        /// Get a copy of all live touch points
        /// </summary>
        /// <returns></returns>
        internal List<Touch> GetAllTouches()
        {
            return touchController.GetAllTouches();
        }

        internal GestureController GestureController
        {
            get
            {
                return gestureController;
            }
        }

        internal GestureListenerController ListenerController
        {
            get
            {
                return listenerController;
            }
        }

        /// <summary>
        /// Initialize all documents
        /// </summary>
        public async void Init(ViewControllers viewControllers) {
            //Initialize controllers
            this.viewControllers = viewControllers;
            documentController = new DocumentController(this);
            cardController = new CardController(this);
            sortingBoxController = new SortingBoxController(this);
            touchController = new TouchController(this);
            gestureController = new GestureController(this);
            listenerController = new GestureListenerController(this);

            //Load the documents, cards and add them to the card layer
            Document[] docs = await documentController.Init(FilePath.NewsArticle);//Load the document
            Card[] cards = await cardController.Init(docs);
            await viewControllers.LoadCardsToCardLayer(cards);

            //Load the sorting box and add them to the sorting box layer
            sortingBoxController.Init();

            //For debug... 
            sortingBoxController.CreateSortingBox("alex", User.ALEX);
            await viewControllers.LoadSortingBoxesToSortingBoxLayer(sortingBoxController.GetAllSortingBoxes());

            touchController.Init();
            gestureController.Init();
            listenerController.Init();

            //Start the gesture detection thread
            gestureController.StartGestureDetection();
        }
        /// <summary>
        /// Create a sorting box
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="content"></param>
        internal void CreateSortingBox(User owner, string content)
        {
            sortingBoxController.CreateSortingBox(content, owner);
        }

        /// <summary>
        /// Destroy the interaction listener
        /// </summary>
        internal void Deinit()
        {
            gestureController.Deinit();
            touchController.Deinit();
            sortingBoxController.Deinit();
            cardController.Deinit();
            documentController.Deinit();
        }
        /// <summary>
        /// Get all cards
        /// </summary>
        /// <returns></returns>
        internal Card[] GetAllCards() {
            return cardController.GetCard();
        }
        /// <summary>
        /// Get all sorting boxes.
        /// </summary>
        /// <returns></returns>
        internal SortingBox[] GetAllSortingBoxs() {
            return sortingBoxController.GetAllSortingBoxes();
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
