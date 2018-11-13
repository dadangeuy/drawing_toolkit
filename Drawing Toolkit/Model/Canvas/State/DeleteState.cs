using Drawing_Toolkit.Model.Drawing;
using Drawing_Toolkit.Model.Drawing.State;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Drawing_Toolkit.Model.Canvas.State {
    class DeleteState : CanvasState {
        public static readonly DeleteState INSTANCE = new DeleteState();
        private DeleteState() { }

        public override void KeyUp(CanvasContext context, KeyEventArgs args) {
            if (args.KeyCode == Keys.Delete) {
                var removed = GetDrawingInEditState(context);
                RemoveAll(context.Drawings, removed);
                context.State = SelectState.INSTANCE;
            }
        }

        private LinkedList<DrawingObject> GetDrawingInEditState(CanvasContext context) {
            var drawings = new LinkedList<DrawingObject>();
            foreach (var drawing in context.Drawings)
                if (drawing.State == EditState.INSTANCE)
                    drawings.AddLast(drawing);
            return drawings;
        }

        private void RemoveAll(LinkedList<DrawingObject> sourceList, LinkedList<DrawingObject> removedList) {
            foreach (var removed in removedList)
                sourceList.Remove(removed);
        }
    }
}
