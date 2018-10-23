using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing_Toolkit.Util {
    class RectangleUtil {
        public static Rectangle FromPoint(Point a, Point b) {
            return Rectangle.FromLTRB(
                Math.Min(a.X, b.X),
                Math.Min(a.Y, b.Y),
                Math.Max(a.X, b.X),
                Math.Max(a.Y, b.Y)
            );
        }
    }
}
