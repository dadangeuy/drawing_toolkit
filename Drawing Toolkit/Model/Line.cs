using System.Drawing;

namespace Drawing_Toolkit.Model {
    class Line : Shape {
        protected override void DrawInternal(Graphics graphics) {
            graphics.DrawLine(pen, from, to);
        }
    }
}
