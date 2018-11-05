using System.Drawing;
using Drawing_Toolkit.Model.Drawing.Shape;
using Drawing_Toolkit.Model.Drawing;
using Drawing_Toolkit.Model.Drawing.State;
using System.Windows.Forms;

namespace Drawing_Toolkit.Model.Canvas.State {
    class CreateRectangleState : CanvasState {
        public static readonly CreateRectangleState INSTANCE = new CreateRectangleState();
        private CreateRectangleState() { }

        private SingleDrawingContext drawing;
        private Point initialLocation;
        private bool resizeDrawing = false;

        public override void MouseDown(CanvasContext context, MouseEventArgs args) {
            drawing = new SingleDrawingContext(new RectangleShape());
            context.Drawings.AddFirst(drawing);

            initialLocation = args.Location;
            resizeDrawing = true;
        }

        public override void MouseMove(CanvasContext context, MouseEventArgs args) {
            if (resizeDrawing) {
                drawing.Resize(initialLocation, args.Location);
            }
        }

        public override void MouseUp(CanvasContext context, MouseEventArgs args) {
            drawing.State = LockState.INSTANCE;
            resizeDrawing = false;
        }
    }
}
