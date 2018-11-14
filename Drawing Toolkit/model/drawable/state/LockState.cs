using Drawing_Toolkit.model.drawable.shape;

namespace Drawing_Toolkit.model.drawable.state {
    internal class LockState : DrawingState {
        public static readonly LockState INSTANCE = new LockState();
        private LockState() { }

        public override void Render(IShape shape) {
            shape.RenderShape();
        }
    }
}