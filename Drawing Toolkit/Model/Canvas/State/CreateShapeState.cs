using Drawing_Toolkit.Model.Drawing;
using Drawing_Toolkit.Model.Drawing.State;
using System.Windows.Forms;

namespace Drawing_Toolkit.Model.Canvas.State {
    abstract class CreateShapeState : CanvasState {
        public override void MouseDown(CanvasContext context, MouseEventArgs args) {
            var drawing = CreateDrawingInternal();
            context.NewDrawing = drawing;
            context.Drawings.AddFirst(drawing);
            context.InitialLocation = args.Location;
        }

        protected abstract DrawingObject CreateDrawingInternal();

        public override void MouseMove(CanvasContext context, MouseEventArgs args) {
            var drawing = context.NewDrawing;
            var initialLocation = context.InitialLocation;
            drawing.Resize(initialLocation, args.Location);
        }

        public override void MouseUp(CanvasContext context, MouseEventArgs args) {
            var drawing = context.NewDrawing;
            drawing.State = LockState.INSTANCE;
        }
    }
}
