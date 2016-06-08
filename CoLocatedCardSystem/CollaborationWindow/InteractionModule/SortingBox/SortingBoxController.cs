using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    public class SortingBoxController
    {
        SortingBoxList list;
        InteractionControllers interactionControllers;

        public SortingBoxController(InteractionControllers interactionControllers)
        {
            this.interactionControllers = interactionControllers;
        }

        /// <summary>
        /// Initialize the sorting box controller
        /// </summary>
        public void Init() {
            list = new SortingBoxList();           
        }
        /// <summary>
        /// Destroy all sorting boxes
        /// </summary>
        public void Deinit() {
            list.Clear();
        }
        /// <summary>
        /// Based on the user, create a sorting box.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="user"></param>
        public void CreateSortingBox(string name, User user) {
            //TO DO: initialize the sorting box with the user info.
            UserInfo userInfo = UserInfo.GetUserInfo(user);
            list.AddBox(userInfo, name, this);
        }
        /// <summary>
        /// Add a card to the sortingbox
        /// </summary>
        /// <param name="card"></param>
        /// <param name="box"></param>
        public void AddCardToSortingBox(Card card, SortingBox box) {
            box.AddCard(card);
        }

        public void RemoveCardFromSortingBox(Card card, SortingBox box) {
            box.RemoveCard(card);
        }

        List<SortingBox> FindAllSortingBoxesByCard(Card card) {
            List<SortingBox> boxes = new List<SortingBox>();
            foreach(SortingBox box in list.GetAllSortingBoxes()) {
                foreach(Card cd in box.CardList) {
                    if (card.CardID == cd.CardID) {
                        boxes.Add(box);
                    }
                }
            }
            return boxes;
        }

        bool ContainCard(SortingBox box, Card card) {
            foreach (Card cd in box.CardList) {
                if (card.CardID == cd.CardID) {
                    return true;
                }
            }
            return false;
        }

        void DestroyBox(SortingBox box) {
            box = null;
        }

        internal void PointerDown(PointerPoint p, Card card, Type type) {
            interactionControllers.OnTouchDown(p, card, type);
        }

        internal void PointerMove(PointerPoint p) {
            interactionControllers.OnTouchMove(p);
        }

        internal void PointerUp(PointerPoint p) {
            interactionControllers.OnTouchUp(p);
        }
    }
}
