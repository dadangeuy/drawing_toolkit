using Drawing_Toolkit.Model.Drawing;
using Drawing_Toolkit.Model.Drawing.Shape;
using Drawing_Toolkit.Model.Drawing.State;
using System.Drawing;

namespace Drawing_Toolkit.Model.Canvas.State {
    class CreateEllipseState : CanvasState {
        public static readonly CreateEllipseState INSTANCE = new CreateEllipseState();
        private CreateEllipseState() { }

        private DrawingContext drawing;
        private Point mouseDownLocation;
        private bool resizeDrawing = false;

        public override void MouseDown(CanvasContext context, Point location) {
            drawing = new DrawingContext(new EllipseShape());
            context.Drawings.AddFirst(drawing);

            mouseDownLocation = location;
            resizeDrawing = true;
        }

        public override void MouseMove(CanvasContext context, Point location) {
            if (resizeDrawing) {
                drawing.Resize(mouseDownLocation, location);
            }
        }

        public override void MouseUp(CanvasContext context, Point location) {
            drawing.Resize(mouseDownLocation, location);
            drawing.SetState(LockState.INSTANCE);
            resizeDrawing = false;
        }
    }
}
