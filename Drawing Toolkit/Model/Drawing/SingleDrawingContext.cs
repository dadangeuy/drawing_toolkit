using Drawing_Toolkit.Model.Drawing.Shape;
using System.Drawing;

namespace Drawing_Toolkit.Model.Drawing {
    class SingleDrawingContext : DrawingContext {
        private readonly IShape shape;

        public SingleDrawingContext(IShape shape) {
            this.shape = shape;
        }

        public override void Move(Point offset) {
            State.Move(shape, offset);
        }

        public override void Resize(Point from, Point to) {
            State.Resize(shape, from, to);
        }

        public override bool Intersect(Point location) {
            return shape.Intersect(location);
        }

        public override void Render(Graphics graphics) {
            shape.SetGraphics(graphics);
            State.Render(shape);
        }
    }
}
