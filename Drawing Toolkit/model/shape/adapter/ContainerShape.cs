using System.Drawing;
using System.Drawing.Drawing2D;
using Drawing_Toolkit.util;

namespace Drawing_Toolkit.model.shape.adapter {
    internal abstract class ContainerShape : IShape {
        protected static readonly Pen ShapePen = new Pen(Color.Black);

        protected static readonly Pen ContainerPen = new Pen(Color.Red) {
            Width = 2,
            DashStyle = DashStyle.Dot
        };

        private Rectangle Container;
        private Graphics Graphics;

        public void SetGraphics(Graphics graphics) {
            this.Graphics = graphics;
        }

        public virtual void SetShape(Point from, Point to) {
            Container = RectangleUtil.FromPoint(from, to);
        }

        public virtual void Move(Point offset) {
            Container.Offset(offset);
        }

        public virtual void MoveFrom(Point offset) { }

        public virtual void MoveTo(Point offset) { }

        public bool Intersect(Point location) {
            return Container.Contains(location);
        }

        public bool Intersect(Rectangle area) {
            return Container.IntersectsWith(area);
        }

        public void RenderShape() {
            RenderInternal(Graphics, ShapePen, Container);
        }

        public void RenderShapeContainer() {
            Graphics.DrawRectangle(ContainerPen, Container);
        }

        protected abstract void RenderInternal(Graphics graphics, Pen pen, Rectangle container);
    }
}