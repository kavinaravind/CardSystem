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
        /// Add a sorting box to the list
        /// </summary>
        /// <param name="name"></param>
        internal void AddBox(UserInfo userInfo, string name) {
            string sortingBoxID = Guid.NewGuid().ToString();
            SortingBox box = new SortingBox();
            box.Init(sortingBoxID, name, userInfo);
            list.Add(sortingBoxID, box);
        }
        /// <summary>
        /// Add a sorting box to the list if the box does not exist
        /// </summary>
        /// <param name="box"></param>
        internal void AddBox(SortingBox box) {
        }
        /// <summary>
        /// Delete a sorting box
        /// </summary>
        /// <param name="box"></param>
        internal void RemoveSortingBox(SortingBox box) {

        }
        /// <summary>
        /// Delete all sorting boxes
        /// </summary>
        internal void Clear() {
        }
        /// <summary>
        /// Return all sorting box that a card belongs to
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        internal SortingBox[] GetSortingBoxByCard(Card card) {
            return null;
        }
        /// <summary>
        /// Get all cards in a sorting box
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        internal Card[] GetCardsBySortingBox(SortingBox box) {
            return null;
        }
        /// <summary>
        /// Get all sorting boxes.
        /// </summary>
        /// <returns></returns>
        internal SortingBox[] GetAllSortingBoxes() {
            return null;
        }
    }
}
