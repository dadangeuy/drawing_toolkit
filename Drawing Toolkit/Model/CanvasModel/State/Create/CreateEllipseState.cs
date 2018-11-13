﻿using Drawing_Toolkit.Model.DrawableModel;
using Drawing_Toolkit.Model.DrawableModel.Shape;

namespace Drawing_Toolkit.Model.CanvasModel.State.Create {
    class CreateEllipseState : CreateShapeState {
        public static readonly CreateEllipseState INSTANCE = new CreateEllipseState();
        private CreateEllipseState() { }

        protected override Drawable CreateDrawingInternal() {
            return new SingleDrawable(new EllipseShape());
        }
    }
}