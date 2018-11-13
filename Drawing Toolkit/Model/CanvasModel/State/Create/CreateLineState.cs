﻿using Drawing_Toolkit.Model.DrawableModel;
using Drawing_Toolkit.Model.DrawableModel.Impl;
using Drawing_Toolkit.Model.DrawableModel.Shape;
using Drawing_Toolkit.Model.DrawableModel.Shape.Impl;

namespace Drawing_Toolkit.Model.CanvasModel.State.Create {
    class CreateLineState : CreateShapeState {
        public static readonly CreateLineState INSTANCE = new CreateLineState();
        private CreateLineState() { }

        protected override Drawable CreateNewDrawable() {
            return new SingleDrawable(new LineShape());
        }
    }
}
