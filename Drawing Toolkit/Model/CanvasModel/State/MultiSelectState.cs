using System.Windows.Forms;
using Drawing_Toolkit.Model.DrawableModel;
using Drawing_Toolkit.Model.DrawableModel.State;

namespace Drawing_Toolkit.Model.CanvasModel.State {
    class MultiSelectState : CanvasState {
        public static readonly MultiSelectState INSTANCE = new MultiSelectState();
        private MultiSelectState() { }

        public override void KeyUp(Canvas context, KeyEventArgs args) {
            if (args.KeyCode == Keys.ShiftKey) context.State = SelectState.INSTANCE;
        }

        public override void MouseDown(Canvas context, MouseEventArgs args) {
            Drawable drawable = GetSelectedDrawable(context, args);

            bool notIntersect = drawable == null;
            if (notIntersect) return;

            bool inEditState = drawable.State == EditState.INSTANCE;
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
