using Drawing_Toolkit.Model.Drawing;
using Drawing_Toolkit.Model.Drawing.Shape;

namespace Drawing_Toolkit.Model.Canvas.State.Create {
    class CreateEllipseState : CreateShapeState {
        public static readonly CreateEllipseState INSTANCE = new CreateEllipseState();
        private CreateEllipseState() { }

        protected override Drawable CreateDrawingInternal() {
            return new SingleDrawable(new EllipseShape());
        }
    }
}
