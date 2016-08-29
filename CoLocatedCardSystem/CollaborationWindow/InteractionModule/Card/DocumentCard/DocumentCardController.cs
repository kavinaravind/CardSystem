using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    class DocumentCardController:CardController
    {
        DocumentCardList list;

        public DocumentCardController(CentralControllers ctrls) : base(ctrls)
        {
        }

        /// <summary>
        /// Initialize the cardController with a list of documents
        /// </summary>
        /// <param name="documents"></param>
        public async Task<Card[]> Init(Document[] documents)
        {
            list = new DocumentCardList();
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
        public void Deinit()
        {
            list.Clear();
        }
        /// <summary>
        /// Add a card to the user
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="user"></param>
        public void AddCard(Document doc, User user)
        {
            //TO DO: add a document to the user. Information is in user info
            UserInfo userInfo = UserInfo.GetUserInfo(user);

        }
        /// <summary>
        /// Get card by id
        /// </summary>
        /// <param name="cardID"></param>
        /// <returns></returns>
        public Card GetCard(string cardID)
        {
            return list.GetCard(cardID);
        }
        /// <summary>
        /// Get all the cards.
        /// </summary>
        /// <returns></returns>
        public Card[] GetCard()
        {
            return list.GetCard();
        }
        /// <summary>
        /// Get all the cards belong to a user. The returned results are references.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Card[] GetCard(User user)
        {
            return list.GetCard(user);
        }
    }
}
