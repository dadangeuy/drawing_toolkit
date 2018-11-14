using System.Drawing;
using Drawing_Toolkit.model.shape.adapter;

namespace Drawing_Toolkit.model.shape.impl {
    internal class EllipseShape : ContainerShape {
        protected override void RenderInternal(Graphics graphics, Pen pen, Rectangle container) {
            graphics.DrawEllipse(pen, container);
        }
    }
}