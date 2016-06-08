using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void Init(Document[] documents) {
            //To Do: add documents in the list to all LIVE users.
            UserInfo alex = UserInfo.GetUserInfo(User.ALEX);//example to get alex's user info
            list = new SemanticCardList();
            foreach (Document doc in documents) {
                foreach (UserInfo info in UserInfo.GetUserInfo()) {
                    if (info.IsLive) {
                        list.AddCard(doc, info);
                    }
                }
            }        
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
        public Card[] GetAllCards() {
            return list.GetAllCards();
        }
    }
}
