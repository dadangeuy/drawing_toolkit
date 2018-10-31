using System.Collections.Generic;
using System.Drawing;
using Drawing_Toolkit.Model.Drawing;

namespace Drawing_Toolkit.Model.Canvas.State {
    class SelectionState : CanvasState {
        public static readonly SelectionState INSTANCE = new SelectionState();
        private SelectionState() { }

        public override void ClickDrawing(LinkedList<DrawingContext> drawings, Point location) {
            foreach (var drawing in drawings)
                drawing.Deselect();
            foreach (var drawing in drawings)
                if (drawing.Intersect(location)) {
                    drawing.Select();
                    break;
                }
        }

        public override void DragDrawing(LinkedList<DrawingContext> drawings, Point from, Point to) {
            foreach (var drawing in drawings)
                if (drawing.Intersect(from)) {
                    Point offset = new Point(to.X - from.X, to.Y - from.Y);
                    drawing.Move(offset);
                    break;
                }
        }
    }
}
