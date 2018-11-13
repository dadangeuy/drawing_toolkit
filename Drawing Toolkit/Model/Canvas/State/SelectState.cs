using System.Collections.Generic;
using System.Windows.Forms;
using Drawing_Toolkit.Model.Drawable;
using Drawing_Toolkit.Model.Drawable.State;

namespace Drawing_Toolkit.Model.Canvas.State {
    class SelectState : CanvasState {
        public static readonly SelectState INSTANCE = new SelectState();
        private SelectState() { }

        public override void KeyDown(Canvas context, KeyEventArgs args) {
            if (args.KeyCode == Keys.ShiftKey) context.State = MultiSelectState.INSTANCE;
            else if (args.KeyCode == Keys.Delete) context.State = DeleteState.INSTANCE;
        }

        public override void KeyUp(Canvas context, KeyEventArgs args) {
            if (args.Control && args.KeyCode == Keys.G) {
                var editDrawings = GetAllDrawingInEditState(context);
                if (editDrawings.Count > 1) {
                    foreach (var drawing in editDrawings)
                        context.Drawings.Remove(drawing);
                    var GroupDrawing = new GroupDrawable(editDrawings);
                    context.Drawings.AddFirst(GroupDrawing);
                }
            }
        }

        private LinkedList<Drawable.Drawable> GetAllDrawingInEditState(Canvas context) {
            var drawings = new LinkedList<Drawable.Drawable>();
            foreach (var drawing in context.Drawings)
                if (drawing.State == EditState.INSTANCE)
                    drawings.AddLast(drawing);
            return drawings;
        }

        public override void MouseDown(Canvas context, MouseEventArgs args) {
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
                    LockAllDrawing(context);
                    intersectDrawing.State = EditState.INSTANCE;
                }
            }
        }

        private Drawable.Drawable GetIntersectDrawing(Canvas context, MouseEventArgs args) {
            foreach (var drawing in context.Drawings)
                if (drawing.Intersect(args.Location))
                    return drawing;
            return null;
        }

        private void LockAllDrawing(Canvas context) {
            foreach (var drawing in context.Drawings)
                drawing.State = LockState.INSTANCE;
        }
    }
}
