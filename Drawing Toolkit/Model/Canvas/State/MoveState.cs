using Drawing_Toolkit.Model.Drawing.State;
using System.Drawing;
using System.Windows.Forms;

namespace Drawing_Toolkit.Model.Canvas.State {
    class MoveState : CanvasState {
        public static readonly MoveState INSTANCE = new MoveState();
        private MoveState() { }

        private Point initialLocation;
        private bool move = false;

        public override void MouseDown(CanvasContext context, MouseEventArgs args) {
            if (HasIntersect(context, args)) {
                initialLocation = args.Location;
                move = true;
            } else {
                foreach (var drawing in context.Drawings) drawing.State = LockState.INSTANCE;
                context.State = SelectState.INSTANCE;
            }
        }

        public override void MouseMove(CanvasContext context, MouseEventArgs args) {
            if (move) {
                var location = args.Location;
                foreach (var drawing in context.Drawings) {
                    var offset = new Point(location.X - initialLocation.X, location.Y - initialLocation.Y);
                    drawing.Move(offset);
                }
                initialLocation = args.Location;
            }
        }

        public override void MouseUp(CanvasContext context, MouseEventArgs args) {
            move = false;
        }

        private bool HasIntersect(CanvasContext context, MouseEventArgs args) {
            foreach (var drawing in context.Drawings)
                if (drawing.State == EditState.INSTANCE && drawing.Intersect(args.Location))
                    return true;
            return false;
        }
    }
}
