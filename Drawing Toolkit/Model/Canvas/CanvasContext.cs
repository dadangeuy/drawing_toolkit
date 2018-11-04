using Drawing_Toolkit.Common;
using Drawing_Toolkit.Model.Canvas.State;
using Drawing_Toolkit.Model.Drawing;
using System.Collections.Generic;
using System.Drawing;

namespace Drawing_Toolkit.Model.Canvas {
    class CanvasContext : StateContext<CanvasState> {
        public CanvasContext() : base(SelectState.INSTANCE) { }

        public List<DrawingContext> Drawings { get; } = new List<DrawingContext>(100);

        public void MouseDown(Point location) {
            State.MouseDown(this, location);
        }

        public void MouseMove(Point location) {
            State.MouseMove(this, location);
        }

        public void MouseUp(Point location) {
            State.MouseUp(this, location);
        }

        public void Render(Graphics graphics) {
            foreach (var drawing in Drawings) {
                drawing.SetGraphics(graphics);
                drawing.Render();
            }
        }
    }
}
