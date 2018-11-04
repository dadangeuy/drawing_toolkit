using Drawing_Toolkit.Model.Drawing.State;
using System.Drawing;
using System.Windows.Forms;

namespace Drawing_Toolkit.Model.Canvas.State {
    class GroupSelectState : CanvasState {
        public static readonly GroupSelectState INSTANCE = new GroupSelectState();
        private GroupSelectState() { }

        public override void KeyUp(CanvasContext context, KeyEventArgs args) {
            if (args.KeyCode == Keys.ShiftKey) context.State = SelectState.INSTANCE;
        }

        public override void MouseDown(CanvasContext context, Point location) {
            foreach (var drawing in context.Drawings) {
                if (drawing.Intersect(location)) {
                    drawing.State = EditState.INSTANCE;
                    return;
                }
            }
        }
    }
}
