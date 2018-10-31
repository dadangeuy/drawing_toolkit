using Drawing_Toolkit.Model.Drawing;
using Drawing_Toolkit.Model.Drawing.Shape;
using System.Collections.Generic;
using System.Drawing;

namespace Drawing_Toolkit.Model.Canvas.State {
    class CreateRectangleState : CanvasState {
        public static readonly CreateRectangleState INSTANCE = new CreateRectangleState();
        private CreateRectangleState() { }

        public override void DragDrawing(LinkedList<DrawingContext> drawings, Point from, Point to) {
            RectangleShape shape = new RectangleShape();
            shape.SetContainer(from, to);
            DrawingContext drawing = new DrawingContext(shape);
            drawings.AddFirst(drawing);
        }
    }
}
