using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
using CoLocatedCardSystem.CollaborationWindow.GestureModule;
using CoLocatedCardSystem.CollaborationWindow.InteractionModule;
using CoLocatedCardSystem.CollaborationWindow.TouchModule;
using System;
using System.Threading.Tasks;
using Windows.UI.Input;
using System.Collections.Generic;
using CoLocatedCardSystem.CollaborationWindow.Layers;

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
        public async void Init(ViewControllers viewControllers)
        {
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
            await viewControllers.CardLayerController.LoadCards(cards);

            //Load the sorting box and add them to the sorting box layer
            sortingBoxController.Init();

            await viewControllers.SortingBoxLayerController.LoadBoxes(sortingBoxController.GetAllSortingBoxes());

            touchController.Init();
            gestureController.Init();
            listenerController.Init();

            //Start the gesture detection thread
            gestureController.StartGestureDetection();
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
        /// Get all active menu bars
        /// </summary>
        /// <returns></returns>
        internal MenuBar[] GetAllMenuBar()
        {
            return viewControllers.MenuLayerController.GetAllMenuBars();
        }
        /// <summary>
        /// Move the card to the top
        /// </summary>
        /// <param name="card"></param>
        internal void MoveCardToTop(Card card)
        {
            viewControllers.CardLayerController.MoveCardToTop(card);
        }

        /// <summary>
        /// Move the SortingBox to the top
        /// </summary>
        /// <param name="card"></param>
        internal void MoveSortingBoxToTop(SortingBox box)
        {
            viewControllers.SortingBoxLayerController.MoveSortingBoxToTop(box);
        }
        /// <summary>
        /// Load all sortingboxes to screen
        /// </summary>
        internal async void AddSortingBoxes(SortingBox newBox)
        {
            await viewControllers.SortingBoxLayerController.LoadBoxes(new SortingBox[] { newBox });
        }
    }
}
