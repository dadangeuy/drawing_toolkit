using System.Drawing;
using System.Windows.Forms;

namespace Drawing_Toolkit.Model.Canvas.State {
    class MoveState : CanvasState {
        public static readonly MoveState INSTANCE = new MoveState();
        private MoveState() { }

        private Point initialLocation;

        public override void MouseDown(CanvasContext context, MouseEventArgs args) {
            initialLocation = args.Location;
        }

        public override void MouseMove(CanvasContext context, MouseEventArgs args) {
            var location = args.Location;
            foreach (var drawing in context.Drawings) {
                var offset = new Point(location.X - initialLocation.X, location.Y - initialLocation.Y);
                drawing.Move(offset);
            }
            initialLocation = args.Location;
        }

        public override void MouseUp(CanvasContext context, MouseEventArgs args) {
            context.State = SelectState.INSTANCE;
            context.MouseUp(args);
        }
    }
}
