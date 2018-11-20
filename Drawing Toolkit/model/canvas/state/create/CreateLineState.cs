using System.Drawing;
using System.Windows.Forms;
using Drawing_Toolkit.model.drawable;
using Drawing_Toolkit.model.drawable.impl;
using Drawing_Toolkit.model.shape.impl;

namespace Drawing_Toolkit.model.canvas.state.create {
    internal class CreateLineState : CreateShapeState {
        public static readonly CreateLineState Instance = new CreateLineState();
        private CreateLineState() { }

        protected override Drawable CreateNewDrawable() {
            return new SingleDrawable(new LineShape());
        }
    }
}