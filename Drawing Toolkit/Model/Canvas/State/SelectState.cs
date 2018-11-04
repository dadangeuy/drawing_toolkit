using Drawing_Toolkit.Model.Drawing.State;
using System.Drawing;

namespace Drawing_Toolkit.Model.Canvas.State {
    class SelectState : CanvasState {
        public static readonly SelectState INSTANCE = new SelectState();
        private SelectState() { }

        public override void MouseDown(CanvasContext context, Point location) {
            foreach (var drawing in context.Drawings) {
                if (drawing.Intersect(location)) {
                    drawing.SetState(EditState.INSTANCE);
                    context.SetState(MoveState.INSTANCE);
                    context.MouseDown(location);
                    return;
                }
            }
        }

        public override void MouseUp(CanvasContext context, Point location) {
            foreach (var drawing in context.Drawings) {
                drawing.SetState(LockState.INSTANCE);
            }
        }
    }
}
