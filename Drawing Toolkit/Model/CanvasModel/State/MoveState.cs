using System.Drawing;
using System.Windows.Forms;

namespace Drawing_Toolkit.Model.CanvasModel.State {
    class MoveState : CanvasState {
        public static readonly MoveState INSTANCE = new MoveState();
        private MoveState() { }

        public override void MouseDown(Canvas context, MouseEventArgs args) {
            context.InitialLocation = args.Location;
        }

        public override void MouseMove(Canvas context, MouseEventArgs args) {
            var location = args.Location;
            var initialLocation = context.InitialLocation;
            foreach (var drawing in context.Drawings) {
                var offset = new Point(location.X - initialLocation.X, location.Y - initialLocation.Y);
                drawing.Move(offset);
            }
            context.InitialLocation = location;
        }

        public override void MouseUp(Canvas context, MouseEventArgs args) {
            context.State = SelectState.INSTANCE;
        }
    }
}
