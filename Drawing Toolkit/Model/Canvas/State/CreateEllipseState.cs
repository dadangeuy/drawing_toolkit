using Drawing_Toolkit.Model.Drawing;
using Drawing_Toolkit.Model.Drawing.Shape;
using System.Collections.Generic;
using System.Drawing;

namespace Drawing_Toolkit.Model.Canvas.State {
    class CreateEllipseState : CanvasState {
        public static readonly CreateEllipseState INSTANCE = new CreateEllipseState();
        private CreateEllipseState() { }

        public override void DragDrawing(LinkedList<DrawingContext> drawings, Point from, Point to) {
            EllipseShape shape = new EllipseShape();
            shape.SetContainer(from, to);
            DrawingContext drawing = new DrawingContext(shape);
            drawings.AddFirst(drawing);
        }
    }
}
