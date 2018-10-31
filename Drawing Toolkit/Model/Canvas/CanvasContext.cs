using Drawing_Toolkit.Model.Canvas.State;
using Drawing_Toolkit.Model.Drawing;
using System.Collections.Generic;
using System.Drawing;

namespace Drawing_Toolkit.Model.Canvas {
    class CanvasContext {
        private CanvasState state = SelectionState.INSTANCE;
        private LinkedList<DrawingContext> drawings = new LinkedList<DrawingContext>();

        public void SetState(CanvasState state) {
            this.state = state;
        }

        public void Render(Graphics graphics) {
            foreach (var drawing in drawings) {
                drawing.SetGraphics(graphics);
                drawing.Render();
            }
        }

        public void AddDrawing(DrawingContext drawing) {
            drawings.AddFirst(drawing);
        }

        public void Click(Point position) {
            state.ClickDrawing(drawings, position);
        }

        public void Drag(Point from, Point to) {
            state.DragDrawing(drawings, from, to);
        }

        private void SelectIfIntersect(Point clickPosition) {
            foreach (var drawing in drawings)
                if (drawing.Intersect(clickPosition)) {
                    drawing.Select();
                    break;
                }
        }

        private void DeselectAll() {
            foreach (var drawing in drawings)
                drawing.Deselect();
        }
    }
}
