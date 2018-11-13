using Drawing_Toolkit.Model.Drawing;
using Drawing_Toolkit.Model.Drawing.Shape;

namespace Drawing_Toolkit.Model.Canvas.State.Create {
    class CreateRectangleState : CreateShapeState {
        public static readonly CreateRectangleState INSTANCE = new CreateRectangleState();
        private CreateRectangleState() { }

        protected override Drawable CreateDrawingInternal() {
            return new SingleDrawable(new RectangleShape());
        }
    }
}
