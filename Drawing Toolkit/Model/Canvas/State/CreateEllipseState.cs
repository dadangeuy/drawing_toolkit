﻿using Drawing_Toolkit.Model.Drawing;
using Drawing_Toolkit.Model.Drawing.Shape;

namespace Drawing_Toolkit.Model.Canvas.State {
    class CreateEllipseState : CreateShapeState {
        public static readonly CreateEllipseState INSTANCE = new CreateEllipseState();
        private CreateEllipseState() { }

        protected override DrawingContext CreateDrawingInternal() {
            return new SingleDrawingContext(new EllipseShape());
        }
    }
}
