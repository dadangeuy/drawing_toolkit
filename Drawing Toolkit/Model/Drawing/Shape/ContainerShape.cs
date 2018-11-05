using Drawing_Toolkit.Util;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Drawing_Toolkit.Model.Drawing.Shape {
    abstract class ContainerShape : IShape {
        protected static readonly Pen SHAPE_PEN = new Pen(Color.Black);
        protected static readonly Pen CONTAINER_PEN = new Pen(Color.Red) {
            DashStyle = DashStyle.Dot
        };
        private Rectangle container;
        private Graphics graphics;

        public void SetGraphics(Graphics graphics) {
            this.graphics = graphics;
        }

        public virtual void SetShape(Point from, Point to) {
            container = RectangleUtil.FromPoint(from, to);
        }

        public virtual void Move(Point offset) {
            container.Offset(offset);
        }

        public bool Intersect(Point location) {
            return container.Contains(location);
        }

        public void RenderShape() {
            RenderInternal(graphics, SHAPE_PEN, container);
        }

        protected abstract void RenderInternal(Graphics graphics, Pen pen, Rectangle container);

        public void RenderShapeContainer() {
            graphics.DrawRectangle(CONTAINER_PEN, container);
        }
    }
}
