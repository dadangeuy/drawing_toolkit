using System.Drawing;

namespace Drawing_Toolkit.Model.DrawableModel {
    class EmptyDrawingContext : Drawable {
        public override bool Intersect(Point location) {
            return false;
        }

        public override bool Intersect(Rectangle area) {
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