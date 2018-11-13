﻿using System.Drawing;
using Drawing_Toolkit.Model.DrawableModel.Shape;

namespace Drawing_Toolkit.Model.DrawableModel.State {
    class EditState : DrawingState {
        public static readonly EditState INSTANCE = new EditState();
        private EditState() { }

        public override void Render(IShape shape) {
            shape.RenderShape();
            shape.RenderShapeContainer();
        }

        public override void Move(IShape shape, Point offset) {
            shape.Move(offset);
        }

        public override void Resize(IShape shape, Point from, Point to) {
            shape.SetShape(from, to);
        }
    }
}