using System.Drawing;
using Drawing_Toolkit.model.shape;

namespace Drawing_Toolkit.model.drawable.state {
    internal class EditState : DrawingState {
        public static readonly EditState Instance = new EditState();
        private EditState() { }

        public override void Render(IShape shape) {
            shape.RenderShape();
            shape.RenderShapeContainer();
        }

        public override void Move(IShape shape, Point offset) {
            shape.Move(offset);
        }

        public override void Resize(IShape shape, Point from, Point to) {
            shape.SetShape(from, to);
        }
    }
}