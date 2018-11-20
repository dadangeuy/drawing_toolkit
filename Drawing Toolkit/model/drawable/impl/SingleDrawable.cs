using System.Drawing;
using Drawing_Toolkit.model.shape;

namespace Drawing_Toolkit.model.drawable.impl {
    internal class SingleDrawable : Drawable {
        private readonly IShape Shape;

        public SingleDrawable(IShape shape) {
            this.Shape = shape;
        }

        public override void Move(Point offset) {
            State.Move(Shape, offset);
            NotifyUpdate();
        }

        public override void Resize(Point from, Point to) {
            State.Resize(Shape, from, to);
            NotifyUpdate();
        }

        public override bool Intersect(Point location) {
            return Shape.Intersect(location);
        }

        public override bool Intersect(Rectangle area) {
            return Shape.Intersect(area);
        }

        public override void Render(Graphics graphics) {
            Shape.SetGraphics(graphics);
            State.Render(Shape);
        }
    }
}