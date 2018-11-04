using Drawing_Toolkit.Model.Drawing.Shape;

namespace Drawing_Toolkit.Model.Drawing.State {
    class LockState : DrawingState {
        public static readonly LockState INSTANCE = new LockState();
        private LockState() { }

        public override void Render(IShape shape) {
            shape.RenderShape();
        }
    }
}
