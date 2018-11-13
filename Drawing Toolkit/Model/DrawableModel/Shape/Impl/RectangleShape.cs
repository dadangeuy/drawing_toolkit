using System.Drawing;
using Drawing_Toolkit.Model.DrawableModel.Shape.Adapter;

namespace Drawing_Toolkit.Model.DrawableModel.Shape.Impl {
    class RectangleShape : ContainerShape {
        protected override void RenderInternal(Graphics graphics, Pen pen, Rectangle container) {
            graphics.DrawRectangle(pen, container);
        }
    }
}
