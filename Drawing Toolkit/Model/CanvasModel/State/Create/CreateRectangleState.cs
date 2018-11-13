using Drawing_Toolkit.Model.DrawableModel;
using Drawing_Toolkit.Model.DrawableModel.Impl;
using Drawing_Toolkit.Model.DrawableModel.Shape;

namespace Drawing_Toolkit.Model.CanvasModel.State.Create {
    class CreateRectangleState : CreateShapeState {
        public static readonly CreateRectangleState INSTANCE = new CreateRectangleState();
        private CreateRectangleState() { }

        protected override Drawable CreateNewDrawable() {
            return new SingleDrawable(new RectangleShape());
        }
    }
}
