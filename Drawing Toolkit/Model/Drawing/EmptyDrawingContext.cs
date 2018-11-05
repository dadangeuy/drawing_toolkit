using System.Drawing;

namespace Drawing_Toolkit.Model.Drawing {
    class EmptyDrawingContext : DrawingContext {
        public override bool Intersect(Point location) {
            return false;
        }

        public override void Move(Point offset) {
        }

        public override void Render(Graphics graphics) {
        }

        public override void Resize(Point from, Point to) {
        }
    }
}
