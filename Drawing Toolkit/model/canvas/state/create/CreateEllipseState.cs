using Drawing_Toolkit.model.drawable;
using Drawing_Toolkit.model.drawable.impl;
using Drawing_Toolkit.model.drawable.shape.impl;

namespace Drawing_Toolkit.model.canvas.state.create {
    internal class CreateEllipseState : CreateShapeState {
        public static readonly CreateEllipseState INSTANCE = new CreateEllipseState();
        private CreateEllipseState() { }

        protected override Drawable CreateNewDrawable() {
            return new SingleDrawable(new EllipseShape());
        }
    }
}