using System.Drawing;
using System;
using Drawing_Toolkit.Model.Drawing.Shape;
using Drawing_Toolkit.Model.Drawing;
using Drawing_Toolkit.Model.Drawing.State;

namespace Drawing_Toolkit.Model.Canvas.State {
    class CreateRectangleState : CanvasState {
        public static readonly CreateRectangleState INSTANCE = new CreateRectangleState();
        private CreateRectangleState() { }

        private DrawingContext drawing;
        private Point initialLocation;
        private bool resizeDrawing = false;

        public override void MouseDown(CanvasContext context, Point location) {
            drawing = new DrawingContext(new RectangleShape());
            context.Drawings.Add(drawing);

            initialLocation = location;
            resizeDrawing = true;
        }

        public override void MouseMove(CanvasContext context, Point location) {
            if (resizeDrawing) {
                drawing.Resize(initialLocation, location);
            }
        }

        public override void MouseUp(CanvasContext context, Point location) {
            drawing.SetState(LockState.INSTANCE);
            resizeDrawing = false;
        }
    }
}
