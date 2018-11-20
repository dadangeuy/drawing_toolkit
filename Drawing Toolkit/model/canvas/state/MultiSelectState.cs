using System.Windows.Forms;
using Drawing_Toolkit.model.drawable;
using Drawing_Toolkit.model.drawable.state;

namespace Drawing_Toolkit.model.canvas.state {
    internal class MultiSelectState : CanvasState {
        public static readonly MultiSelectState Instance = new MultiSelectState();
        private MultiSelectState() { }

        public override void KeyUp(Canvas context, KeyEventArgs args) {
            if (args.KeyCode == Keys.ShiftKey) context.State = SelectState.Instance;
        }

        public override void MouseDown(Canvas context, MouseEventArgs args) {
            var drawable = GetSelectedDrawable(context, args);

            var notIntersect = drawable == null;
            if (notIntersect) return;

            var inEditState = drawable.State == EditState.Instance;
            if (inEditState) drawable.State = LockState.Instance;
            else drawable.State = EditState.Instance;
        }

        private Drawable GetSelectedDrawable(Canvas context, MouseEventArgs args) {
            foreach (var drawing in context.Drawables)
                if (drawing.Intersect(args.Location))
                    return drawing;
            return null;
        }
    }
}