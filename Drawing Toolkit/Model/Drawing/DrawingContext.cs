using Drawing_Toolkit.Model.Drawing.Shape;
using Drawing_Toolkit.Model.Drawing.State;
using System;
using System.Drawing;

namespace Drawing_Toolkit.Model.Drawing {
    class DrawingContext {
        private DrawingState state = EditState.INSTANCE;
        private readonly IShape shape;

        public DrawingContext(IShape shape) {
            this.shape = shape;
        }

        public void SetState(DrawingState state) {
            this.state = state;
        }

        public void Render() {
            state.Render(shape);
        }

        public void Move(Point offset) {
            state.Move(shape, offset);
        }

        public void Resize(Point from, Point to) {
            state.Resize(shape, from, to);
        }

        public void SetGraphics(Graphics g) {
            shape.SetGraphics(g);
        }

        public bool Intersect(Point location) {
            return shape.Intersect(location);
        }
    }
}
