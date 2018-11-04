using Drawing_Toolkit.Model.Canvas.State;
using Drawing_Toolkit.Model.Drawing;
using System.Collections.Generic;
using System.Drawing;

namespace Drawing_Toolkit.Model.Canvas {
    class CanvasContext {
        private CanvasState state = SelectionState.INSTANCE;
        public LinkedList<DrawingContext> Drawings { get; } = new LinkedList<DrawingContext>();

        public void SetState(CanvasState state) {
            this.state = state;
        }

        public void MouseDown(Point location) {
            state.MouseDown(this, location);
        }

        public void MouseMove(Point location) {
            state.MouseMove(this, location);
        }

        public void MouseUp(Point location) {
            state.MouseUp(this, location);
        }

        public void Render(Graphics graphics) {
            foreach (var drawing in Drawings) {
                drawing.SetGraphics(graphics);
                drawing.Render();
            }
        }
    }
}
