using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace CoLocatedCardSystem.CollaborationWindow
{
    class Coordination
    {
        static FrameworkElement baselayer;

        public static FrameworkElement Baselayer
        {
            get
            {
                return baselayer;
            }

            set
            {
                baselayer = value;
            }
        }
        /// <summary>
        /// Return a point list of the absolute position of the four element corners.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private static Point[] GetScreenPosition(FrameworkElement element, bool isCentered)
        {
            var ttv = element.TransformToVisual(Window.Current.Content);
            Point topLeft = isCentered ? ttv.TransformPoint(new Point(-0.5 * element.Width, -0.5 * element.Height)) : ttv.TransformPoint(new Point(0, 0));
            Point topRight = isCentered ? ttv.TransformPoint(new Point(0.5 * element.Width, -0.5 * element.Height)) : ttv.TransformPoint(new Point(element.Width, 0));
            Point bottomLeft = isCentered ? ttv.TransformPoint(new Point(-0.5 * element.Width, 0.5 * element.Height)) : ttv.TransformPoint(new Point(0, element.Height));
            Point bottomRight = isCentered ? ttv.TransformPoint(new Point(0.5 * element.Width, 0.5 * element.Height)) : ttv.TransformPoint(new Point(element.Width, element.Height));
            return new Point[] { topLeft, topRight, bottomRight, bottomLeft };
        }
        /// <summary>
        /// Check if the point falls in the element, isCentered denotes whether the 0 point of the
        /// object is in the center or the top left corner
        /// </summary>
        /// <param name="point"></param>
        /// <param name="element"></param>
        /// <param name="isCentered"></param>
        /// <returns></returns>
        public static bool IsIntersect(Point point, FrameworkElement element, bool isCentered)
        {
            Point[] polygon = GetScreenPosition(element, isCentered);
            bool isInside = false;
            for (int i = 0, j = polygon.Length - 1; i < polygon.Length; j = i++)
            {
                if (((polygon[i].Y > point.Y) != (polygon[j].Y > point.Y)) &&
                (point.X < (polygon[j].X - polygon[i].X) * (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) + polygon[i].X))
                {
                    isInside = !isInside;
                }
            }
            return isInside;
        }
    }
}
