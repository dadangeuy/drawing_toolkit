using Drawing_Toolkit.Common;
using Drawing_Toolkit.Model.Drawing.Shape;
using Drawing_Toolkit.Model.Drawing.State;
using System.Drawing;

namespace Drawing_Toolkit.Model.Drawing {
    class DrawingContext : StateContext<DrawingState>, IDrawing {
        private readonly IShape shape;

        public DrawingContext(IShape shape) : base(EditState.INSTANCE) {
            this.shape = shape;
        }

        public void Move(Point offset) {
            State.Move(shape, offset);
        }

        public void Resize(Point from, Point to) {
            State.Resize(shape, from, to);
        }

        public bool Intersect(Point location) {
            return shape.Intersect(location);
        }

        public void Render(Graphics graphics) {
            shape.SetGraphics(graphics);
            State.Render(shape);
        }
    }
}
