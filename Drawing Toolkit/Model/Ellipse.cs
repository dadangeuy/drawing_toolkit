using System.Drawing;

namespace Drawing_Toolkit.Model {
    class Ellipse : Shape {
        protected override void DrawInternal(Graphics graphics) {
            int width = getWidth();
            int height = getHeight();
            Point point = getLeftUpPoint();
            graphics.DrawEllipse(pen, point.X, point.Y, width, height);
        }
    }
}
