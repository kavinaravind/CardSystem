﻿using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    class DocumentCardList
    { 
        Dictionary<string, DocumentCard> list=new Dictionary<string, DocumentCard>();//Key: random card id.

        /// <summary>
        /// Add a new card to the user.
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="cardInfo"></param>
        /// <returns></returns>
        internal async Task AddCard(Document doc,User user, CardController cardController) {
            string cardID = Guid.NewGuid().ToString();
            DocumentCard card = new DocumentCard(cardController);
            list.Add(cardID, card);
            card.Init(cardID, user);
            await card.LoadDocument(doc);
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
            list.Clear();
        }
        /// <summary>
        /// Get the card by cardID
        /// </summary>
        /// <param name="cardID"></param>
        /// <returns></returns>
        internal DocumentCard GetCard(string cardID) {
            return list[cardID];
        }
        /// <summary>
        /// Return all card instances
        /// </summary>
        /// <returns></returns>
        internal Card[] GetCard()
        {
            return list.Values.ToArray<Card>();
        }
        /// <summary>
        /// Get references to all cards belong to a specific user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        internal Card[] GetCard(User user) {
            var cardList =list.Values.Where(a => a.Owner.Equals(user));
            return cardList.ToArray<Card>();
        }
    }
}
