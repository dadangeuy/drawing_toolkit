﻿using Drawing_Toolkit.Model.Drawing.Shape;
using Drawing_Toolkit.Model.Drawing;

namespace Drawing_Toolkit.Model.Canvas.State {
    class CreateRectangleState : CreateShapeState {
        public static readonly CreateRectangleState INSTANCE = new CreateRectangleState();
        private CreateRectangleState() { }

        protected override DrawingObject CreateDrawingInternal() {
            return new SingleDrawingObject(new RectangleShape());
        }
    }
}
