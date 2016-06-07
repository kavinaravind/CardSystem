using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    public class SortingBoxController
    {
        SortingBoxList list;
        /// <summary>
        /// Initialize the sorting box controller
        /// </summary>
        public void Init() {
            list = new SortingBoxList();           
        }
        /// <summary>
        /// Destroy all sorting boxes
        /// </summary>
        public void Deinit()
        {
        }
        /// <summary>
        /// Based on the user, create a sorting box.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="user"></param>
        public void CreateSortingBox(string name, User user) {
            //TO DO: initialize the sorting box with the user info.
            UserInfo userInfo = UserInfo.GetUserInfo(user);

        }
        /// <summary>
        /// Add a card to the sortingbox
        /// </summary>
        /// <param name="card"></param>
        /// <param name="box"></param>
        public void AddCardToSortingBox(Card card, SortingBox box) {

        }
    }
}
