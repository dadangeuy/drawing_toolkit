using Drawing_Toolkit.Model.Drawable;
using Drawing_Toolkit.Model.Drawable.Shape;

namespace Drawing_Toolkit.Model.Canvas.State.Create {
    class CreateRectangleState : CreateShapeState {
        public static readonly CreateRectangleState INSTANCE = new CreateRectangleState();
        private CreateRectangleState() { }

        protected override Drawable.Drawable CreateDrawingInternal() {
            return new SingleDrawable(new RectangleShape());
        }
    }
}
