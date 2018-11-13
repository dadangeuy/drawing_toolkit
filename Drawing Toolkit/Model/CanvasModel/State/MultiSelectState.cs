﻿using System.Windows.Forms;
using Drawing_Toolkit.Model.DrawableModel;
using Drawing_Toolkit.Model.DrawableModel.State;

namespace Drawing_Toolkit.Model.CanvasModel.State {
    class MultiSelectState : CanvasState {
        public static readonly MultiSelectState INSTANCE = new MultiSelectState();
        private MultiSelectState() { }

        public override void KeyUp(Canvas context, KeyEventArgs args) {
            if (args.KeyCode == Keys.ShiftKey) context.State = SelectState.INSTANCE;
        }

        public override void MouseDown(Canvas context, MouseEventArgs args) {
            Drawable drawing = GetIntersectDrawing(context, args);
            bool intersect = drawing != null;
            if (intersect) {
                bool inEditState = drawing.State == EditState.INSTANCE;
                if (inEditState) drawing.State = LockState.INSTANCE;
                else drawing.State = EditState.INSTANCE;
            }
        }

        private Drawable GetIntersectDrawing(Canvas context, MouseEventArgs args) {
            foreach (var drawing in context.Drawings)
                if (drawing.Intersect(args.Location))
                    return drawing;
            return null;
        }
    }
}