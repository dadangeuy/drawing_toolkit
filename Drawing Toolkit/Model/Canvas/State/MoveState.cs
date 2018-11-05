using System.Drawing;
using System.Windows.Forms;

namespace Drawing_Toolkit.Model.Canvas.State {
    class MoveState : CanvasState {
        public static readonly MoveState INSTANCE = new MoveState();
        private MoveState() { }

        public override void MouseDown(CanvasContext context, MouseEventArgs args) {
            context.InitialLocation = args.Location;
        }

        public override void MouseMove(CanvasContext context, MouseEventArgs args) {
            var location = args.Location;
            var initialLocation = context.InitialLocation;
            foreach (var drawing in context.Drawings) {
                var offset = new Point(location.X - initialLocation.X, location.Y - initialLocation.Y);
                drawing.Move(offset);
            }
            context.InitialLocation = location;
        }

        public override void MouseUp(CanvasContext context, MouseEventArgs args) {
            context.State = SelectState.INSTANCE;
        }
    }
}
