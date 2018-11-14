using System.Collections.Generic;
using System.Windows.Forms;
using Drawing_Toolkit.model.drawable;
using Drawing_Toolkit.model.drawable.impl;
using Drawing_Toolkit.model.drawable.state;

namespace Drawing_Toolkit.model.canvas.state {
    internal class SelectState : CanvasState {
        public static readonly SelectState INSTANCE = new SelectState();
        private SelectState() { }

        public override void KeyDown(Canvas context, KeyEventArgs args) {
            if (args.KeyCode == Keys.ShiftKey) context.State = MultiSelectState.INSTANCE;
            else if (args.KeyCode == Keys.Delete) context.State = DeleteState.INSTANCE;
        }

        public override void KeyUp(Canvas context, KeyEventArgs args) {
            if (args.Control && args.KeyCode == Keys.G) GroupDrawings(context);
        }

        public override void MouseDown(Canvas context, MouseEventArgs args) {
            var drawable = GetSelectedDrawable(context, args);
            var noIntersect = drawable == null;
            if (noIntersect) {
                LockDrawables(context);
            }
            else {
                var inEditState = drawable.State == EditState.INSTANCE;
                if (inEditState) MoveDrawable(context, args);
                else SelectDrawable(context, drawable);
            }
        }

        private void GroupDrawings(Canvas context) {
            var drawables = GetDrawablesInEditState(context);

            var uselessToGroup = drawables.Count <= 1;
            if (uselessToGroup) return;

            foreach (var drawing in drawables) context.Drawables.Remove(drawing);
            var GroupDrawing = new GroupDrawable(drawables);
            context.Drawables.AddFirst(GroupDrawing);
        }

        private LinkedList<Drawable> GetDrawablesInEditState(Canvas context) {
            var drawables = new LinkedList<Drawable>();
            foreach (var drawing in context.Drawables)
                if (drawing.State == EditState.INSTANCE)
                    drawables.AddLast(drawing);
            return drawables;
        }

        private Drawable GetSelectedDrawable(Canvas context, MouseEventArgs args) {
            foreach (var drawable in context.Drawables)
                if (drawable.Intersect(args.Location))
                    return drawable;
            return null;
        }

        private void MoveDrawable(Canvas context, MouseEventArgs args) {
            context.State = MoveState.INSTANCE;
            context.MouseDown(args);
        }

        private void SelectDrawable(Canvas context, Drawable drawable) {
            LockDrawables(context);
            drawable.State = EditState.INSTANCE;
        }

        private void LockDrawables(Canvas context) {
            foreach (var drawable in context.Drawables) drawable.State = LockState.INSTANCE;
        }
    }
}