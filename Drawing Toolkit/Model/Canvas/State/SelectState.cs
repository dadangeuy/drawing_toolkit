using Drawing_Toolkit.Model.Drawing;
using Drawing_Toolkit.Model.Drawing.State;
using System.Windows.Forms;

namespace Drawing_Toolkit.Model.Canvas.State {
    class SelectState : CanvasState {
        public static readonly SelectState INSTANCE = new SelectState();
        private SelectState() { }

        public override void MouseDown(CanvasContext context, MouseEventArgs args) {
            var intersectDrawing = GetIntersectDrawing(context, args);
            bool noIntersect = intersectDrawing == null;
            if (noIntersect) {
                LockAllDrawing(context);
            } else {
                bool inEditState = intersectDrawing.State == EditState.INSTANCE;
                if (inEditState) {
                    context.State = MoveState.INSTANCE;
                    context.MouseDown(args);
                } else {
                    intersectDrawing.State = EditState.INSTANCE;
                }
            }
        }

        private DrawingApi GetIntersectDrawing(CanvasContext context, MouseEventArgs args) {
            foreach (var drawing in context.Drawings)
                if (drawing.Intersect(args.Location))
                    return drawing;
            return null;
        }

        private void LockAllDrawing(CanvasContext context) {
            foreach (var drawing in context.Drawings)
                drawing.State = LockState.INSTANCE;
        }
    }
}
