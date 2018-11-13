using Drawing_Toolkit.Model.DrawableModel;
using Drawing_Toolkit.Model.DrawableModel.Impl;
using Drawing_Toolkit.Model.DrawableModel.Shape;
using Drawing_Toolkit.Model.DrawableModel.Shape.Impl;

namespace Drawing_Toolkit.Model.CanvasModel.State.Create {
    class CreateEllipseState : CreateShapeState {
        public static readonly CreateEllipseState INSTANCE = new CreateEllipseState();
        private CreateEllipseState() { }

        protected override Drawable CreateNewDrawable() {
            return new SingleDrawable(new EllipseShape());
        }
    }
}
