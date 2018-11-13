using System.Windows.Forms;
using Drawing_Toolkit.Model.Drawing;
using Drawing_Toolkit.Model.Drawing.State;

namespace Drawing_Toolkit.Model.Canvas.State.Create {
    abstract class CreateShapeState : CanvasState {
        public override void MouseDown(Canvas context, MouseEventArgs args) {
            var drawing = CreateDrawingInternal();
            context.NewDrawing = drawing;
            context.Drawings.AddFirst(drawing);
            context.InitialLocation = args.Location;
        }

        protected abstract Drawable CreateDrawingInternal();

        public override void MouseMove(Canvas context, MouseEventArgs args) {
            var drawing = context.NewDrawing;
            var initialLocation = context.InitialLocation;
            drawing.Resize(initialLocation, args.Location);
        }

        public override void MouseUp(Canvas context, MouseEventArgs args) {
            var drawing = context.NewDrawing;
            drawing.State = LockState.INSTANCE;
        }
    }
}
