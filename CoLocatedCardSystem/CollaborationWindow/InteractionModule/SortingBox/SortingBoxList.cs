using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    class SortingBoxList
    {
        Dictionary<string, SortingBox> list=new Dictionary<string, SortingBox>();
        /// <summary>
        /// Add a sorting box to the list. Return the added box
        /// </summary>
        /// <param name="name"></param>
        internal SortingBox AddBox(User user, string name, SortingBoxController controller) {
            string sortingBoxID = Guid.NewGuid().ToString();
            SortingBox box = new SortingBox(controller);
            box.Init(sortingBoxID, name, user);
            list.Add(sortingBoxID, box);
            return box;
        }
        /// <summary>
        /// Add a sorting box to the list if the box does not exist
        /// </summary>
        /// <param name="box"></param>
        internal void AddBox(SortingBox box) {
            list.Add(box.SortingBoxID, box);
        }

        /// <summary>
        /// Add a sorting box to the list if the box does not exist
        /// </summary>
        /// <param name="box"></param>
        internal void AddBox(string name) {
            // implement
        }

        /// <summary>
        /// Delete a sorting box
        /// </summary>
        /// <param name="box"></param>
        internal void RemoveSortingBox(SortingBox box) {
            list.Remove(box.SortingBoxID);
        }
        /// <summary>
        /// Delete all sorting boxes
        /// </summary>
        internal void Clear() {
            list.Clear();
        }
        /// <summary>
        /// Return all sorting box that a card belongs to
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        internal List<SortingBox> GetSortingBoxByCard(Card card) {
            List<SortingBox> boxes = new List<SortingBox>();
            foreach (SortingBox box in list.Values.ToList()) {
                foreach (Card cd in box.CardList) {
                    if (cd.CardID == card.CardID) {
                        boxes.Add(box);
                    }
                }
            }
            return boxes;
        }
        /// <summary>
        /// Get all cards in a sorting box
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        internal List<Card> GetCardsBySortingBox(SortingBox box) {
            return box.CardList;
        }
        /// <summary>
        /// Get all sorting boxes.
        /// </summary>
        /// <returns></returns>
        internal SortingBox[] GetAllSortingBoxes() {
            return list.Values.ToArray();
        }
    }
}
