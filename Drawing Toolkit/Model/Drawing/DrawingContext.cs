using Drawing_Toolkit.Common;
using Drawing_Toolkit.Model.Drawing.Shape;
using Drawing_Toolkit.Model.Drawing.State;
using System.Drawing;

namespace Drawing_Toolkit.Model.Drawing {
    class DrawingContext : StateContext<DrawingState> {
        private readonly IShape shape;

        public DrawingContext(IShape shape) : base(EditState.INSTANCE) {
            this.shape = shape;
        }

        public void Render() {
            State.Render(shape);
        }

        public void Move(Point offset) {
            State.Move(shape, offset);
        }

        public void Resize(Point from, Point to) {
            State.Resize(shape, from, to);
        }

        public void SetGraphics(Graphics g) {
            shape.SetGraphics(g);
        }

        public bool Intersect(Point location) {
            return shape.Intersect(location);
        }
    }
}
