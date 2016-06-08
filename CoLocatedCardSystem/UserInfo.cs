using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;

namespace CoLocatedCardSystem
{
    public class UserInfo
    {
        /// <summary>
        /// Use this class to access the default setting of the users.
        /// </summary>
        protected User user = User.ALEX;
        private bool isLive = true;
        protected Size cardSize = new Size(160, 120);
        private Size sortingBoxSize = new Size(60, 45);
        protected Color cardColor = Colors.Red;
        protected Point cardPosition = new Point(0, 0);
        protected double cardScale = 1;
        protected double cardRotation = 1;
        protected Color sortingBoxColor = Colors.Red;
        protected Point sortingBoxPosition = new Point(0, 0);
        protected double sortingBoxScale = 1;
        protected double sortingBoxRotation = 1;
        protected static Dictionary<User, UserInfo> userList = new Dictionary<User, UserInfo>();

        public User User
        {
            get
            {
                return user;
            }
        }
        public Color CardColor
        {
            get
            {
                return cardColor;
            }
        }
        public Point CardPosition
        {
            get
            {
                return cardPosition;
            }
        }
        public double CardScale
        {
            get
            {
                return cardScale;
            }
        }
        public double CardRotation
        {
            get
            {
                return cardRotation;
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
        }

        public Size CardSize
        {
            get
            {
                return cardSize;
            }
        }

        public Size SortingBoxSize
        {
            get
            {
                return sortingBoxSize;
            }
        }

        public bool IsLive
        {
            get
            {
                return isLive;
            }
        }

        /// <summary>
        /// Get the userinfo with User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static UserInfo GetUserInfo(User user)
        {
            return userList[user];
        }
        public static UserInfo[] GetUserInfo() {
            return userList.Values.ToArray();
        }
        static UserInfo()
        {
            userList.Add(User.ALEX, InitAlex());
            userList.Add(User.BEN, InitBen());
            userList.Add(User.CHRIS, InitChris());
            userList.Add(User.DANNY, InitDanny());
        }
        /// <summary>
        /// Initialize Alex's user info
        /// </summary>
        /// <returns></returns>
        private static UserInfo InitAlex()
        {
            UserInfo userInfo = new UserInfo();
            userInfo.user = User.ALEX;
            userInfo.isLive = true;
            userInfo.cardColor = Colors.Red;
            userInfo.cardPosition = new Point(0, 0);
            userInfo.cardScale = 1;
            userInfo.cardRotation = 1;
            userInfo.sortingBoxColor = Colors.Red;
            userInfo.sortingBoxPosition = new Point(0, 0);
            userInfo.sortingBoxScale = 1;
            userInfo.sortingBoxRotation = 1;
            return userInfo;
        }
        /// <summary>
        /// Initialize Ben's user info
        /// </summary>
        /// <returns></returns>
        private static UserInfo InitBen()
        {
            UserInfo userInfo = new UserInfo();
            userInfo.user = User.BEN;
            userInfo.isLive = true;
            userInfo.cardColor = Colors.Red;
            userInfo.cardPosition = new Point(0, 0);
            userInfo.cardScale = 1;
            userInfo.cardRotation = 1;
            userInfo.sortingBoxColor = Colors.Red;
            userInfo.sortingBoxPosition = new Point(0, 0);
            userInfo.sortingBoxScale = 1;
            userInfo.sortingBoxRotation = 1;
            return userInfo;
        }
        /// <summary>
        /// Initialize Chris's user info
        /// </summary>
        /// <returns></returns>
        private static UserInfo InitChris()
        {
            UserInfo userInfo = new UserInfo();
            userInfo.user = User.CHRIS;
            userInfo.isLive = true;
            userInfo.cardColor = Colors.Red;
            userInfo.cardPosition = new Point(0, 0);
            userInfo.cardScale = 1;
            userInfo.cardRotation = 1;
            userInfo.sortingBoxColor = Colors.Red;
            userInfo.sortingBoxPosition = new Point(0, 0);
            userInfo.sortingBoxScale = 1;
            userInfo.sortingBoxRotation = 1;
            return userInfo;
        }
        /// <summary>
        /// Initialize Danny's user info
        /// </summary>
        /// <returns></returns>
        private static UserInfo InitDanny()
        {
            UserInfo userInfo = new UserInfo();
            userInfo.user = User.DANNY;
            userInfo.isLive = false;
            userInfo.cardColor = Colors.Red;
            userInfo.cardPosition = new Point(0, 0);
            userInfo.cardScale = 1;
            userInfo.cardRotation = 1;
            userInfo.sortingBoxColor = Colors.Red;
            userInfo.sortingBoxPosition = new Point(0, 0);
            userInfo.sortingBoxScale = 1;
            userInfo.sortingBoxRotation = 1;
            return userInfo;
        }
    }
}
