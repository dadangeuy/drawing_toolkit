using System.Drawing;

namespace Drawing_Toolkit.Model.Canvas.State {
    class MoveState : CanvasState {
        public static readonly MoveState INSTANCE = new MoveState();
        private MoveState() { }

        private Point initialLocation;

        public override void MouseDown(CanvasContext context, Point location) {
            initialLocation = location;
        }

        public override void MouseMove(CanvasContext context, Point location) {
            foreach (var drawing in context.Drawings) {
                Point offset = new Point(location.X - initialLocation.X, location.Y - initialLocation.Y);
                drawing.Move(offset);
            }
            initialLocation = location;
        }

        public override void MouseUp(CanvasContext context, Point location) {
            context.State = SelectState.INSTANCE;
            context.MouseUp(location);
        }
    }
}
