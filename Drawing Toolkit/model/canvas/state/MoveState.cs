using System.Drawing;
using System.Windows.Forms;

namespace Drawing_Toolkit.model.canvas.state {
    internal class MoveState : CanvasState {
        public static readonly MoveState INSTANCE = new MoveState();
        private MoveState() { }

        public override void MouseDown(Canvas context, MouseEventArgs args) {
            context.InitialLocation = args.Location;
        }

        public override void MouseMove(Canvas context, MouseEventArgs args) {
            var location = args.Location;
            var initialLocation = context.InitialLocation;
            var offset = new Point(location.X - initialLocation.X, location.Y - initialLocation.Y);
            MoveDrawables(context, offset);
            context.InitialLocation = location;
        }

        public override void MouseUp(Canvas context, MouseEventArgs args) {
            context.State = SelectState.INSTANCE;
        }

        private void MoveDrawables(Canvas context, Point offset) {
            foreach (var drawable in context.Drawables) drawable.Move(offset);
        }
    }
}