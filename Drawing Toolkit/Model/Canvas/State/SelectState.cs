﻿using Drawing_Toolkit.Model.Drawing.State;
using System.Windows.Forms;

namespace Drawing_Toolkit.Model.Canvas.State {
    class SelectState : CanvasState {
        public static readonly SelectState INSTANCE = new SelectState();
        private SelectState() { }

        public override void KeyDown(CanvasContext context, KeyEventArgs args) {
            if (args.KeyCode == Keys.ShiftKey) context.State = GroupSelectState.INSTANCE;
        }

        public override void MouseDown(CanvasContext context, MouseEventArgs args) {
            var location = args.Location;
            foreach (var drawing in context.Drawings) {
                if (drawing.Intersect(location)) {
                    drawing.State = EditState.INSTANCE;
                    context.State = MoveState.INSTANCE;
                    context.MouseDown(args);
                    return;
                }
            }
        }

        public override void MouseUp(CanvasContext context, MouseEventArgs args) {
            foreach (var drawing in context.Drawings) {
                drawing.State = LockState.INSTANCE;
            }
        }
    }
}
