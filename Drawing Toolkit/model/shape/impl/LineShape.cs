﻿using System.Drawing;
using Drawing_Toolkit.model.shape.adapter;

namespace Drawing_Toolkit.model.shape.impl {
    internal class LineShape : ContainerShape {
        private Point from;
        private Point to;

        public override void SetShape(Point from, Point to) {
            base.SetShape(from, to);
            this.from = from;
            this.to = to;
        }

        public override void Move(Point offset) {
            base.Move(offset);
            from.Offset(offset);
            to.Offset(offset);
        }

        public override void MoveFrom(Point offset) {
            from.Offset(offset);
            base.SetShape(from, to);
        }

        public override void MoveTo(Point offset) {
            to.Offset(offset);
            base.SetShape(from, to);
        }

        protected override void RenderInternal(Graphics graphics, Pen pen, Rectangle container) {
            graphics.DrawLine(SHAPE_PEN, from, to);
        }
    }
}