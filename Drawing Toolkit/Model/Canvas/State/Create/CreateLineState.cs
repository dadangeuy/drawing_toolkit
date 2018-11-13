using Drawing_Toolkit.Model.Drawable;
using Drawing_Toolkit.Model.Drawable.Shape;

namespace Drawing_Toolkit.Model.Canvas.State.Create {
    class CreateLineState : CreateShapeState {
        public static readonly CreateLineState INSTANCE = new CreateLineState();
        private CreateLineState() { }

        protected override Drawable.Drawable CreateDrawingInternal() {
            return new SingleDrawable(new LineShape());
        }
    }
}
