﻿using Drawing_Toolkit.Util;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Drawing_Toolkit.Model.Drawing.Shape {
    class EllipseShape : ContainerShape {
        protected override void RenderInternal(Graphics graphics, Pen pen, Rectangle container) {
            graphics.DrawEllipse(pen, container);
        }
    }
}
