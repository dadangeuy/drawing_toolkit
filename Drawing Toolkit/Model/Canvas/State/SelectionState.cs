using System.Drawing;
using Drawing_Toolkit.Model.Drawing.State;
using Drawing_Toolkit.Model.Drawing;

namespace Drawing_Toolkit.Model.Canvas.State {
    class SelectionState : CanvasState {
        public static readonly SelectionState INSTANCE = new SelectionState();
        private SelectionState() { }

        private DrawingContext drawing;
        private Point mouseDownLocation;
        private bool moveDrawing = false;

        public override void MouseDown(CanvasContext context, Point location) {
            if (drawing != null) drawing.SetState(LockState.INSTANCE);

            foreach (var drawing in context.Drawings) {
                if (drawing.Intersect(location)) {
                    this.drawing = drawing;
                    drawing.SetState(EditState.INSTANCE);

                    mouseDownLocation = location;
                    moveDrawing = true;

                    return;
                }
            }
        }

        public override void MouseUp(CanvasContext context, Point location) {
            if (moveDrawing) {
                Point offset = new Point(location.X - mouseDownLocation.X, location.Y - mouseDownLocation.Y);
                drawing.Move(offset);
                moveDrawing = false;
            }
        }
    }
}
