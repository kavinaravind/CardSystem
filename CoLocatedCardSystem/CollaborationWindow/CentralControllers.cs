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
    public class CentralControllers
    {
        DocumentController documentController;
        CardController cardController;
        SortingBoxController sortingBoxController;
        TouchController touchController;
        GestureController gestureController;
        GestureListenerController listenerController;

        CentralControllers interactionControllers;
        BaseLayerController baseLayerController;
        CardLayerController cardLayerController;
        LinkingLayerController linkingLayerController;
        MenuLayerController menuLayerController;
        SortingBoxLayerController sortingBoxLayerController;

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
        internal BaseLayerController BaseLayerController
        {
            get
            {
                return baseLayerController;
            }
        }
        internal CardLayerController CardLayerController
        {
            get
            {
                return cardLayerController;
            }
        }
        internal LinkingLayerController LinkingLayerController
        {
            get
            {
                return linkingLayerController;
            }
        }
        internal MenuLayerController MenuLayerController
        {
            get
            {
                return menuLayerController;
            }
        }
        internal SortingBoxLayerController SortingBoxLayerController
        {
            get
            {
                return sortingBoxLayerController;
            }
        }
        /// <summary>
        /// Initialize all documents
        /// </summary>
        public async void Init(int width, int height)
        {
            //Initialize controllers
            documentController = new DocumentController(this);
            cardController = new CardController(this);
            sortingBoxController = new SortingBoxController(this);
            touchController = new TouchController(this);
            gestureController = new GestureController(this);
            listenerController = new GestureListenerController(this);
            baseLayerController = new BaseLayerController(this);
            cardLayerController = new CardLayerController(this);
            sortingBoxLayerController = new SortingBoxLayerController(this);         
            menuLayerController = new MenuLayerController(this);
            //Initialize layers
            touchController.Init();
            gestureController.Init();
            listenerController.Init();
            baseLayerController.Init(width, height);
            Coordination.Baselayer = baseLayerController.BaseLayer;//Set the base layer to the coordination helper
            cardLayerController.Init(width, height);
            sortingBoxLayerController.Init(width, height);
            menuLayerController.Init(width, height);
            //Load the documents, cards and add them to the card layer
            Document[] docs = await documentController.Init(FilePath.NewsArticle);//Load the document
            Card[] cards = await cardController.Init(docs);
            CardLayerController.LoadCards(cards);
            //Load the sorting box and add them to the sorting box layer
            sortingBoxController.Init();
            SortingBoxLayerController.LoadBoxes(sortingBoxController.GetAllSortingBoxes());
            //Start the gesture detection thread
            gestureController.StartGestureDetection();
        }

        /// <summary>
        /// Destroy the interaction listener
        /// </summary>
        internal void Deinit()
        {
            gestureController.Deinit();
            gestureController = null;
            listenerController.Deinit();
            listenerController = null;
            touchController.Deinit();
            touchController = null;
            sortingBoxController.Deinit();
            sortingBoxController = null;
            cardController.Deinit();
            cardController = null;
            documentController.Deinit();
            documentController = null;
            baseLayerController.Deinit();
            baseLayerController = null;
            cardLayerController.Deinit();
            cardLayerController = null;
            sortingBoxLayerController.Deinit();
            sortingBoxLayerController = null;
            menuLayerController.Deinit();
            menuLayerController = null;
        }
    }
}
