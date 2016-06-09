using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
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
        InteractionControllers interactionControllers;
        SemanticCardList list;
        public CardController(InteractionControllers itcCtrlr) {
            this.interactionControllers = itcCtrlr;
        }
        /// <summary>
        /// Initialize the cardController with a list of documents
        /// </summary>
        /// <param name="documents"></param>
        public async Task<Card[]> Init(Document[] documents)
        {
            list = new SemanticCardList();
            foreach (User user in UserInfo.GetLiveUsers())
            {
                foreach (Document doc in documents)
                {
                    await list.AddCard(doc, user, this);
                }
                Card[] cardsToBePlaced = GetCard(user);
                CardLayoutGenerator.ApplyLayout(cardsToBePlaced, user);
            }
            return list.GetCard();
        }
        /// <summary>
        /// Destroy the card list
        /// </summary>
        public void Deinit() {
            list.Clear();
        }
        /// <summary>
        /// Add a card to the user
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="user"></param>
        public void AddCard(Document doc, User user) {
            //TO DO: add a document to the user. Information is in user info
            UserInfo userInfo = UserInfo.GetUserInfo(user);

        }
        /// <summary>
        /// Get card by id
        /// </summary>
        /// <param name="cardID"></param>
        /// <returns></returns>
        public Card GetCard(string cardID) {
            return list.GetCard(cardID);
        }
        /// <summary>
        /// Get all the cards.
        /// </summary>
        /// <returns></returns>
        public Card[] GetCard() {
            return list.GetCard();
        }
        /// <summary>
        /// Get all the cards belong to a user. The returned results are references.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Card[] GetCard(User user) {
            return list.GetCard(user);
        }
        /// <summary>
        /// Create a touch and pass it to the interaction controller.
        /// </summary>
        /// <param name="p"></param>
        internal void PointerDown(PointerPoint p, Card card, Type type)
        {
            interactionControllers.OnTouchDown(p, card, type);
        }
        /// <summary>
        /// Update the touch point
        /// </summary>
        /// <param name="p"></param>
        internal void PointerMove(PointerPoint p)
        {
            interactionControllers.OnTouchMove(p);
        }
        /// <summary>
        /// Lift the touch layer
        /// </summary>
        /// <param name="p"></param>
        internal void PointerUp(PointerPoint p)
        {
            interactionControllers.OnTouchUp(p);
        }
        /// <summary>
        /// Update the ZIndex of the card. Move the card to the top.
        /// </summary>
        /// <param name="card"></param>
        internal void MoveCardToTop(Card card)
        {
            interactionControllers.MoveCardToTop(card);
        }
    }
}
