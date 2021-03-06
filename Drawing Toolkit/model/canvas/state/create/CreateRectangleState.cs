﻿using Drawing_Toolkit.model.drawable;
using Drawing_Toolkit.model.drawable.impl;
using Drawing_Toolkit.model.shape.impl;

namespace Drawing_Toolkit.model.canvas.state.create {
    internal class CreateRectangleState : CreateShapeState {
        public static readonly CreateRectangleState Instance = new CreateRectangleState();
        private CreateRectangleState() { }

        protected override Drawable CreateNewDrawable() {
            return new SingleDrawable(new RectangleShape());
        }
    }
}