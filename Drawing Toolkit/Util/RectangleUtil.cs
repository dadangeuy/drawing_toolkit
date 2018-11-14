using System;
using System.Drawing;

namespace Drawing_Toolkit.util {
    internal class RectangleUtil {
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