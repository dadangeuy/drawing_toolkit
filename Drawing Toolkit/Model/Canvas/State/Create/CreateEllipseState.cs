﻿using Drawing_Toolkit.Model.Drawable;
using Drawing_Toolkit.Model.Drawable.Shape;

namespace Drawing_Toolkit.Model.Canvas.State.Create {
    class CreateEllipseState : CreateShapeState {
        public static readonly CreateEllipseState INSTANCE = new CreateEllipseState();
        private CreateEllipseState() { }

        protected override Drawable.Drawable CreateDrawingInternal() {
            return new SingleDrawable(new EllipseShape());
        }
    }
}
