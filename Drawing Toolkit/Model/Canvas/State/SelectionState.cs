using System.Drawing;
using Drawing_Toolkit.Model.Drawing.State;

namespace Drawing_Toolkit.Model.Canvas.State {
    class SelectionState : CanvasState {
        public static readonly SelectionState INSTANCE = new SelectionState();
        private SelectionState() { }

        private Point initialLocation;

        public override void MouseDown(CanvasContext context, Point location) {
            foreach (var drawing in context.Drawings) {
                if (drawing.Intersect(location)) {
                    drawing.SetState(EditState.INSTANCE);
                    initialLocation = location;
                }
            }
        }

        public override void MouseMove(CanvasContext context, Point location) {
            foreach (var drawing in context.Drawings) {
                Point offset = getOffset(initialLocation, location);
                drawing.Move(offset);
            }
            initialLocation = location;
        }

        public override void MouseUp(CanvasContext context, Point location) {
            foreach (var drawing in context.Drawings) {
                drawing.SetState(LockState.INSTANCE);
            }
        }

        private Point getOffset(Point from, Point to) {
            return new Point(to.X - from.X, to.Y - from.Y);
        }
    }
}
