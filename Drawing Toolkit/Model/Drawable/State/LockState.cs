using Drawing_Toolkit.Model.Drawable.Shape;

namespace Drawing_Toolkit.Model.Drawable.State {
    class LockState : DrawingState {
        public static readonly LockState INSTANCE = new LockState();
        private LockState() { }

        public override void Render(IShape shape) {
            shape.RenderShape();
        }
    }
}
