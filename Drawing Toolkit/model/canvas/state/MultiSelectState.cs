using System.Windows.Forms;
using Drawing_Toolkit.model.drawable;
using Drawing_Toolkit.model.drawable.state;

namespace Drawing_Toolkit.model.canvas.state {
    internal class MultiSelectState : CanvasState {
        public static readonly MultiSelectState INSTANCE = new MultiSelectState();
        private MultiSelectState() { }

        public override void KeyUp(Canvas context, KeyEventArgs args) {
            if (args.KeyCode == Keys.ShiftKey) context.State = SelectState.INSTANCE;
        }

        public override void MouseDown(Canvas context, MouseEventArgs args) {
            var drawable = GetSelectedDrawable(context, args);

            var notIntersect = drawable == null;
            if (notIntersect) return;

            var inEditState = drawable.State == EditState.INSTANCE;
            if (inEditState) drawable.State = LockState.INSTANCE;
            else drawable.State = EditState.INSTANCE;
        }

        private Drawable GetSelectedDrawable(Canvas context, MouseEventArgs args) {
            foreach (var drawing in context.Drawables)
                if (drawing.Intersect(args.Location))
                    return drawing;
            return null;
        }
    }
}