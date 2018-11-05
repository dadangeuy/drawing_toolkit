using Drawing_Toolkit.Common;
using Drawing_Toolkit.Model.Drawing.Shape;
using Drawing_Toolkit.Model.Drawing.State;
using System.Drawing;

namespace Drawing_Toolkit.Model.Drawing {
    class DrawingContext : DrawingApi {
        private readonly IShape shape;

        public DrawingContext(IShape shape) {
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
