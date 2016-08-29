using CoLocatedCardSystem.CollaborationWindow.ClusterModule;
using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
using CoLocatedCardSystem.CollaborationWindow.FileLoaderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    public class CardController
    {
        CentralControllers controllers;
        ItemCardController itemCardController = null;
        DocumentCardController semanticCardController = null;
        ClusterCardController clusterCardController = null;
        PlotCardController plotCardController = null;

        public CardController(CentralControllers ctrls) {
            this.controllers = ctrls;
        }
        internal void Init()
        {
            itemCardController = new ItemCardController(controllers);
            semanticCardController = new DocumentCardController(controllers);
            clusterCardController = new ClusterCardController(controllers);
            plotCardController = new PlotCardController(controllers);
            
        }
        internal async void Deinit() {
            itemCardController.Deinit();
            semanticCardController.Deinit();
            clusterCardController.Deinit();
            plotCardController.Deinit();
        } 
        /// <summary>
        /// Initialize the doc cards
        /// </summary>
        /// <param name="docs"></param>
        /// <returns></returns>                
        internal async Task<Card[]> InitDocCard(Document[] docs) {
            Card[] docCards=null;
            if (docs != null)
            {
                docCards = await semanticCardController.Init(docs);
            }
            return docCards;
        }

        /// <summary>
        /// Initialize the table cards
        /// </summary>
        /// <param name="docs"></param>
        /// <returns></returns>                
        internal async Task<Card[]> InitItemCard(Item[] items)
        {
            Card[] itemCards = null;
            if (items != null)
            {
                itemCards = await itemCardController.Init(items);
            }
            return itemCards;
        }
        /// <summary>
        /// Initialize the plot cards
        /// </summary>
        /// <param name="docs"></param>
        /// <returns></returns>                
        internal async Task<Card[]> InitAttributeCard(FileLoaderModule.Attribute[] attributes)
        {
            Card[] plotCards = null;
            if (attributes != null)
            {
                plotCards = await plotCardController.Init(attributes);
            }
            return plotCards;
        }
        /// <summary>
        /// Initialize the cluster cards
        /// </summary>
        /// <param name="docs"></param>
        /// <returns></returns>                
        internal async Task<Card[]> InitClusterCard(Cluster[] clusters)
        {
            Card[] clusterCards = null;
            if (clusters != null)
            {
                clusterCards = await clusterCardController.Init(clusters);
            }
            return clusterCards;
        }
        /// <summary>
        /// Create a touch and pass it to the interaction controller.
        /// </summary>
        /// <param name="p"></param>
        internal void PointerDown(PointerPoint localPoint, PointerPoint globalPoint, Card card, Type type)
        {
            controllers.TouchController.TouchDown(localPoint,globalPoint, card, type);
        }
        /// <summary>
        /// Update the touch point
        /// </summary>
        /// <param name="p"></param>
        internal void PointerMove(PointerPoint localPoint, PointerPoint globalPoint)
        {
            controllers.TouchController.TouchMove(localPoint, globalPoint);
        }
        /// <summary>
        /// Lift the touch layer
        /// </summary>
        /// <param name="p"></param>
        internal void PointerUp(PointerPoint localPoint, PointerPoint globalPoint)
        {
            controllers.TouchController.TouchUp(localPoint, globalPoint);
        }
        /// <summary>
        /// Update the ZIndex of the card. Move the card to the top.
        /// </summary>
        /// <param name="card"></param>
        internal void MoveCardToTop(Card card)
        {
            controllers.CardLayerController.MoveCardToTop(card);
        }
    }
}
