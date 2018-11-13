using Drawing_Toolkit.Model.DrawableModel.Shape;

namespace Drawing_Toolkit.Model.DrawableModel.State {
    class LockState : DrawingState {
        public static readonly LockState INSTANCE = new LockState();
        private LockState() { }

        public override void Render(IShape shape) {
            shape.RenderShape();
        }
    }
}
