using System.Drawing;

namespace Drawing_Toolkit.Model.DrawableModel {
    class EmptyDrawable : Drawable {
        public static readonly EmptyDrawable INSTANCE = new EmptyDrawable();

        private EmptyDrawable() { }

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