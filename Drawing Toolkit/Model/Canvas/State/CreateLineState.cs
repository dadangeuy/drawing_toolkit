﻿using Drawing_Toolkit.Model.Drawing;
using Drawing_Toolkit.Model.Drawing.Shape;

namespace Drawing_Toolkit.Model.Canvas.State {
    class CreateLineState : CreateShapeState {
        public static readonly CreateLineState INSTANCE = new CreateLineState();
        private CreateLineState() { }

        protected override DrawingContext CreateDrawingInternal() {
            return new SingleDrawingContext(new LineShape());
        }
    }
}