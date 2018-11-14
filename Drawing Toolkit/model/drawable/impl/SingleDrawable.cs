using System.Drawing;
using Drawing_Toolkit.model.shape;

namespace Drawing_Toolkit.model.drawable.impl {
    internal class SingleDrawable : Drawable {
        private readonly IShape shape;

        public SingleDrawable(IShape shape) {
            this.shape = shape;
        }

        public override void ConnectFromPointWith(Drawable drawable) {
        }

        public override void ConnectToPointWith(Drawable drawable) {
        }

        protected override void MoveInternal(Point offset) {
            State.Move(shape, offset);
        }

        public override void Resize(Point from, Point to) {
            State.Resize(shape, from, to);
        }

        public override bool Intersect(Point location) {
            return shape.Intersect(location);
        }

        public override bool Intersect(Rectangle area) {
            return shape.Intersect(area);
        }

        public override void Render(Graphics graphics) {
            shape.SetGraphics(graphics);
            State.Render(shape);
        }
    }
}