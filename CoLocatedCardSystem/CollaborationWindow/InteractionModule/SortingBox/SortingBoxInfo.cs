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
        private Size sortingBoxSize = new Size(200, 200);
        private Color sortingBoxColor = Colors.Red;
        private Point sortingBoxPosition = new Point(900, 500);
        private double sortingBoxScale = 1;
        private double sortingBoxRotation = 1;
        private static Dictionary<User, SortingBoxInfo> sortingBoxInfoList = new Dictionary<User, SortingBoxInfo>();

        public Size SortingBoxSize
        {
            get
            {
                return sortingBoxSize;
            }
        }

        public Color SortingBoxColor
        {
            get
            {
                return sortingBoxColor;
            }
        }

        public Point SortingBoxPosition
        {
            get
            {
                return sortingBoxPosition;
            }
        }

        public double SortingBoxScale
        {
            get
            {
                return sortingBoxScale;
            }
        }

        public double SortingBoxRotation
        {
            get
            {
                return sortingBoxRotation;
            }

            set
            {
                sortingBoxRotation = value;
            }
        }

        static SortingBoxInfo()
        {
            sortingBoxInfoList.Add(User.ALEX, InitAlex());
            sortingBoxInfoList.Add(User.BEN, InitBen());
            sortingBoxInfoList.Add(User.CHRIS, InitChris());
            sortingBoxInfoList.Add(User.DANNY, InitDanny());
        }
        public static SortingBoxInfo GetSortingBoxInfo(User user)
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
            sortingBoxInfo.sortingBoxColor = Colors.Magenta;
            sortingBoxInfo.sortingBoxPosition = new Point(900, 500);
            sortingBoxInfo.sortingBoxScale = 1;
            sortingBoxInfo.SortingBoxRotation = 1;
            return sortingBoxInfo;
        }
        /// <summary>
        /// Initialize Ben's user info
        /// </summary>
        /// <returns></returns>
        private static SortingBoxInfo InitBen()
        {
            SortingBoxInfo sortingBoxInfo = new SortingBoxInfo();
            sortingBoxInfo.sortingBoxColor = Colors.Magenta;
            sortingBoxInfo.sortingBoxPosition = new Point(900, 500);
            sortingBoxInfo.sortingBoxScale = 1;
            sortingBoxInfo.SortingBoxRotation = 1;
            return sortingBoxInfo;
        }
        /// <summary>
        /// Initialize Chris's user info
        /// </summary>
        /// <returns></returns>
        private static SortingBoxInfo InitChris()
        {
            SortingBoxInfo sortingBoxInfo = new SortingBoxInfo();
            sortingBoxInfo.sortingBoxColor = Colors.Magenta;
            sortingBoxInfo.sortingBoxPosition = new Point(900, 500);
            sortingBoxInfo.sortingBoxScale = 1;
            sortingBoxInfo.SortingBoxRotation = 1;
            return sortingBoxInfo;
        }
        /// <summary>
        /// Initialize Danny's user info
        /// </summary>
        /// <returns></returns>
        private static SortingBoxInfo InitDanny()
        {
            SortingBoxInfo sortingBoxInfo = new SortingBoxInfo();
            sortingBoxInfo.sortingBoxColor = Colors.Magenta;
            sortingBoxInfo.sortingBoxPosition = new Point(900, 500);
            sortingBoxInfo.sortingBoxScale = 1;
            sortingBoxInfo.sortingBoxRotation = 1;
            return sortingBoxInfo;
        }
    }
}
