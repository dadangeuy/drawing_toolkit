﻿using Drawing_Toolkit.Model.Drawing;
using Drawing_Toolkit.Model.Drawing.State;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Drawing_Toolkit.Model.Canvas.State {
    class DeleteState : CanvasState {
        public static readonly DeleteState INSTANCE = new DeleteState();
        private DeleteState() { }

        public override void KeyUp(Canvas context, KeyEventArgs args) {
            if (args.KeyCode == Keys.Delete) {
                var removed = GetDrawingInEditState(context);
                RemoveAll(context.Drawings, removed);
                context.State = SelectState.INSTANCE;
            }
        }

        private LinkedList<Drawable> GetDrawingInEditState(Canvas context) {
            var drawings = new LinkedList<Drawable>();
            foreach (var drawing in context.Drawings)
                if (drawing.State == EditState.INSTANCE)
                    drawings.AddLast(drawing);
            return drawings;
        }

        private void RemoveAll(LinkedList<Drawable> sourceList, LinkedList<Drawable> removedList) {
            foreach (var removed in removedList)
                sourceList.Remove(removed);
        }
    }
}
