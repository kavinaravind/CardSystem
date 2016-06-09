using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    class SortingBoxInfo
    {
        private Size sortingBoxSize = new Size(60, 45);
        protected Color sortingBoxColor = Colors.Red;
        protected Point sortingBoxPosition = new Point(0, 0);
        protected double sortingBoxScale = 1;
        protected double sortingBoxRotation = 1;
        protected static Dictionary<User, SortingBoxInfo> sortingBoxInfoList = new Dictionary<User, SortingBoxInfo>();
        static SortingBoxInfo()
        {
            sortingBoxInfoList.Add(User.ALEX, InitAlex());
            sortingBoxInfoList.Add(User.BEN, InitBen());
            sortingBoxInfoList.Add(User.CHRIS, InitChris());
            sortingBoxInfoList.Add(User.DANNY, InitDanny());
        }
        public static SortingBoxInfo GetCardInfo(User user)
        {
            return sortingBoxInfoList[user];
        }
        /// <summary>
        /// Initialize Alex's user info
        /// </summary>
        /// <returns></returns>
        private static SortingBoxInfo InitAlex()
        {
            SortingBoxInfo sortingBoxInfo = new SortingBoxInfo();
            sortingBoxInfo.sortingBoxColor = Colors.Red;
            sortingBoxInfo.sortingBoxPosition = new Point(0, 0);
            sortingBoxInfo.sortingBoxScale = 1;
            sortingBoxInfo.sortingBoxRotation = 1;
            return sortingBoxInfo;
        }
        /// <summary>
        /// Initialize Ben's user info
        /// </summary>
        /// <returns></returns>
        private static SortingBoxInfo InitBen()
        {
            SortingBoxInfo sortingBoxInfo = new SortingBoxInfo();
            sortingBoxInfo.sortingBoxColor = Colors.Red;
            sortingBoxInfo.sortingBoxPosition = new Point(0, 0);
            sortingBoxInfo.sortingBoxScale = 1;
            sortingBoxInfo.sortingBoxRotation = 1;
            return sortingBoxInfo;
        }
        /// <summary>
        /// Initialize Chris's user info
        /// </summary>
        /// <returns></returns>
        private static SortingBoxInfo InitChris()
        {
            SortingBoxInfo sortingBoxInfo = new SortingBoxInfo();
            sortingBoxInfo.sortingBoxColor = Colors.Red;
            sortingBoxInfo.sortingBoxPosition = new Point(0, 0);
            sortingBoxInfo.sortingBoxScale = 1;
            sortingBoxInfo.sortingBoxRotation = 1;
            return sortingBoxInfo;
        }
        /// <summary>
        /// Initialize Danny's user info
        /// </summary>
        /// <returns></returns>
        private static SortingBoxInfo InitDanny()
        {
            SortingBoxInfo sortingBoxInfo = new SortingBoxInfo();
            sortingBoxInfo.sortingBoxColor = Colors.Red;
            sortingBoxInfo.sortingBoxPosition = new Point(0, 0);
            sortingBoxInfo.sortingBoxScale = 1;
            sortingBoxInfo.sortingBoxRotation = 1;
            return sortingBoxInfo;
        }
    }
}
