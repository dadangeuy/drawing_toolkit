using System.Drawing;
using Drawing_Toolkit.Model.Drawing.State;
using Drawing_Toolkit.Model.Drawing;

namespace Drawing_Toolkit.Model.Canvas.State {
    class SelectionState : CanvasState {
        public static readonly SelectionState INSTANCE = new SelectionState();
        private SelectionState() { }

        private DrawingContext drawing;
        private Point initialLocation;
        private bool moveDrawing = false;

        public override void MouseDown(CanvasContext context, Point location) {
            if (drawing != null) drawing.SetState(LockState.INSTANCE);

            foreach (var drawing in context.Drawings) {
                if (drawing.Intersect(location)) {
                    this.drawing = drawing;
                    drawing.SetState(EditState.INSTANCE);

                    initialLocation = location;
                    moveDrawing = true;

                    return;
                }
            }
        }

        public override void MouseMove(CanvasContext context, Point location) {
            if (moveDrawing) {
                Point offset = getOffset(initialLocation, location);
                drawing.Move(offset);
                initialLocation = location;
            }
        }

        public override void MouseUp(CanvasContext context, Point location) {
            moveDrawing = false;
        }

        private Point getOffset(Point from, Point to) {
            return new Point(to.X - from.X, to.Y - from.Y);
        }
    }
}
