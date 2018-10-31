using Drawing_Toolkit.Model.Drawing.Shape;
using Drawing_Toolkit.Model.Drawing.State;
using System;
using System.Drawing;

namespace Drawing_Toolkit.Model.Drawing {
    class DrawingContext {
        private DrawingState state = LockState.INSTANCE;
        private readonly IShape shape;

        public DrawingContext(IShape shape) {
            this.shape = shape;
        }

        public void Select() {
            state = EditState.INSTANCE;
        }

        public void Deselect() {
            state = LockState.INSTANCE;
        }

        public void Render() {
            state.Render(shape);
        }

        public void Move(Point offset) {
            state.Move(shape, offset);
        }

        public void SetGraphics(Graphics g) {
            shape.SetGraphics(g);
        }

        public bool Intersect(Point location) {
            return shape.Intersect(location);
        }
    }
}
