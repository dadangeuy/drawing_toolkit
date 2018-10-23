using System.Drawing;
using Drawing_Toolkit.Model.Shape.Api;
using Drawing_Toolkit.Util;

namespace Drawing_Toolkit.Model.Shape.Impl {
    class RectangleShape : IShape {
        private Rectangle rectangle;
        private Pen pen = new Pen(Color.Black);

        public void SetShape(Point from, Point to) {
            rectangle = RectangleUtil.FromPoint(from, to);
        }

        public void Draw(Graphics g) {
            g.DrawRectangle(pen, rectangle);
        }

        public void Select() {
            pen.Color = Color.Blue;
        }

        public void Deselect() {
            pen.Color = Color.Black;
        }

        public bool Intersect(Point point) {
            return rectangle.Contains(point);
        }

        public void Move(Point difference) {
            rectangle.Offset(difference);
        }
    }
}
