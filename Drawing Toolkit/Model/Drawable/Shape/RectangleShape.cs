using System.Drawing;

namespace Drawing_Toolkit.Model.Drawable.Shape {
    class RectangleShape : ContainerShape {
        protected override void RenderInternal(Graphics graphics, Pen pen, Rectangle container) {
            graphics.DrawRectangle(pen, container);
        }
    }
}
