using Drawing_Toolkit.Model.DrawableModel;
using Drawing_Toolkit.Model.DrawableModel.Shape;

namespace Drawing_Toolkit.Model.CanvasModel.State.Create {
    class CreateLineState : CreateShapeState {
        public static readonly CreateLineState INSTANCE = new CreateLineState();
        private CreateLineState() { }

        protected override Drawable CreateNewDrawable() {
            return new SingleDrawable(new LineShape());
        }
    }
}
