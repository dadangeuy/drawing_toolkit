using Drawing_Toolkit.Model.Drawing;
using Drawing_Toolkit.Model.Drawing.Shape;

namespace Drawing_Toolkit.Model.Canvas.State.Create {
    class CreateLineState : CreateShapeState {
        public static readonly CreateLineState INSTANCE = new CreateLineState();
        private CreateLineState() { }

        protected override Drawable CreateDrawingInternal() {
            return new SingleDrawable(new LineShape());
        }
    }
}
