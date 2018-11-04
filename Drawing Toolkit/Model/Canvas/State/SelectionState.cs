using System.Drawing;
using Drawing_Toolkit.Model.Drawing.State;
using Drawing_Toolkit.Model.Drawing;

namespace Drawing_Toolkit.Model.Canvas.State {
    class SelectionState : CanvasState {
        public static readonly SelectionState INSTANCE = new SelectionState();
        private SelectionState() { }

        private DrawingContext drawing;

        public override void MouseDown(CanvasContext context, Point location) {
            if (drawing != null) drawing.SetState(LockState.INSTANCE);

            foreach (var drawing in context.Drawings) {
                if (drawing.Intersect(location)) {
                    this.drawing = drawing;
                    drawing.SetState(EditState.INSTANCE);
                    break;
                }
            }
        }
    }
}
