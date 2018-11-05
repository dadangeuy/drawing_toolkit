using Drawing_Toolkit.Model.Drawing;
using Drawing_Toolkit.Model.Drawing.State;
using System.Windows.Forms;

namespace Drawing_Toolkit.Model.Canvas.State {
    class MultiSelectState : CanvasState {
        public static readonly MultiSelectState INSTANCE = new MultiSelectState();
        private MultiSelectState() { }

        public override void KeyUp(CanvasContext context, KeyEventArgs args) {
            if (args.KeyCode == Keys.ShiftKey) context.State = SelectState.INSTANCE;
        }

        public override void MouseDown(CanvasContext context, MouseEventArgs args) {
            DrawingContext drawing = GetIntersectDrawing(context, args);
            bool intersect = drawing != null;
            if (intersect) {
                bool inEditState = drawing.State == EditState.INSTANCE;
                if (inEditState) drawing.State = LockState.INSTANCE;
                else drawing.State = EditState.INSTANCE;
            }
        }

        private DrawingContext GetIntersectDrawing(CanvasContext context, MouseEventArgs args) {
            foreach (var drawing in context.Drawings)
                if (drawing.Intersect(args.Location))
                    return drawing;
            return null;
        }
    }
}
