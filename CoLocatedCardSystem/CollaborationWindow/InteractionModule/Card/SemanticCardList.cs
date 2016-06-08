using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    class SemanticCardList
    {
        Dictionary<string, SemanticCard> list=new Dictionary<string, SemanticCard>();
        
        /// <summary>
        /// Add a new card to the user.
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        internal async Task AddCard(Document doc,UserInfo userInfo, CardController cardController) {
            string cardID = Guid.NewGuid().ToString();
            SemanticCard card = new SemanticCard(cardController);
            card.Init(cardID, userInfo);
            await card.LoadDocument(doc);
            list.Add(cardID, card);
        }
        /// <summary>
        /// Remove a card based on its id
        /// </summary>
        /// <param name="cardID"></param>
        internal void RemoveCard(string cardID) {

        }
        /// <summary>
        /// Delete all cards in the card list
        /// </summary>
        internal void Clear() {

        }
        /// <summary>
        /// Get the card by cardID
        /// </summary>
        /// <param name="cardID"></param>
        /// <returns></returns>
        internal SemanticCard GetCard(string cardID) {
            return list[cardID];
        }
        /// <summary>
        /// Return all card instances
        /// </summary>
        /// <returns></returns>
        internal Card[] GetAllCards()
        {
            return list.Values.ToArray<Card>();
        }
    }
}
