using Drawing_Toolkit.Util;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Drawing_Toolkit.Model.Drawing.Shape {
    class EllipseShape : IShape {
        private static readonly Pen SHAPE_PEN = new Pen(Color.Black);
        private static readonly Pen CONTAINER_PEN = new Pen(Color.Red) {
            DashStyle = DashStyle.DashDot
        };
        private Rectangle container;
        private Graphics graphics;

        public void SetGraphics(Graphics graphics) {
            this.graphics = graphics;
        }

        public void SetContainer(Point from, Point to) {
            container = RectangleUtil.FromPoint(from, to);
        }

        public void Move(Point offset) {
            container.Offset(offset);
        }

        public bool Intersect(Point location) {
            return container.Contains(location);
        }

        public void RenderShape() {
            graphics.DrawEllipse(SHAPE_PEN, container);
        }

        public void RenderShapeContainer() {
            graphics.DrawRectangle(CONTAINER_PEN, container);
        }
    }
}
