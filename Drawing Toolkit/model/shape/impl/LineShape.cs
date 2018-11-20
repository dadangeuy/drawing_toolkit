using System.Drawing;
using Drawing_Toolkit.model.shape.adapter;

namespace Drawing_Toolkit.model.shape.impl {
    internal class LineShape : ContainerShape {
        private Point From;
        private Point To;

        public override void SetShape(Point from, Point to) {
            base.SetShape(from, to);
            this.From = from;
            this.To = to;
        }

        public override void Move(Point offset) {
            base.Move(offset);
            From.Offset(offset);
            To.Offset(offset);
        }

        public override void MoveFrom(Point offset) {
            From.Offset(offset);
            base.SetShape(From, To);
        }

        public override void MoveTo(Point offset) {
            To.Offset(offset);
            base.SetShape(From, To);
        }

        protected override void RenderInternal(Graphics graphics, Pen pen, Rectangle container) {
            graphics.DrawLine(ShapePen, From, To);
        }
    }
}