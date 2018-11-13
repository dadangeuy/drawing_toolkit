﻿using System.Drawing;

namespace Drawing_Toolkit.Model.DrawableModel.Shape {
    class EllipseShape : ContainerShape {
        protected override void RenderInternal(Graphics graphics, Pen pen, Rectangle container) {
            graphics.DrawEllipse(pen, container);
        }
    }
}