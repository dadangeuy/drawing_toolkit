using Drawing_Toolkit.model.drawable;
using Drawing_Toolkit.model.drawable.impl;
using Drawing_Toolkit.model.drawable.shape.impl;

namespace Drawing_Toolkit.model.canvas.state.create {
    internal class CreateLineState : CreateShapeState {
        public static readonly CreateLineState INSTANCE = new CreateLineState();
        private CreateLineState() { }

        protected override Drawable CreateNewDrawable() {
            return new SingleDrawable(new LineShape());
        }
    }
}