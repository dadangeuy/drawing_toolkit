using System.Collections.Generic;
using System.Windows.Forms;
using Drawing_Toolkit.model.drawable;
using Drawing_Toolkit.model.drawable.state;

namespace Drawing_Toolkit.model.canvas.state {
    internal class DeleteState : CanvasState {
        public static readonly DeleteState Instance = new DeleteState();
        private DeleteState() { }

        public override void KeyUp(Canvas context, KeyEventArgs args) {
            if (args.KeyCode == Keys.Delete) {
                var removed = GetDrawablesInEditState(context);
                RemoveAll(context.Drawables, removed);
                context.State = SelectState.Instance;
            }
        }

        private LinkedList<Drawable> GetDrawablesInEditState(Canvas context) {
            var drawables = new LinkedList<Drawable>();
            foreach (var drawable in context.Drawables)
                if (drawable.State == EditState.Instance)
                    drawables.AddLast(drawable);
            return drawables;
        }

        private void RemoveAll(LinkedList<Drawable> sourceList, LinkedList<Drawable> removedList) {
            foreach (var removed in removedList)
                sourceList.Remove(removed);
        }
    }
}