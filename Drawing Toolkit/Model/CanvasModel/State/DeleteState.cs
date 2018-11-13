using System.Collections.Generic;
using System.Windows.Forms;
using Drawing_Toolkit.Model.DrawableModel;
using Drawing_Toolkit.Model.DrawableModel.State;

namespace Drawing_Toolkit.Model.CanvasModel.State {
    class DeleteState : CanvasState {
        public static readonly DeleteState INSTANCE = new DeleteState();
        private DeleteState() { }

        public override void KeyUp(Canvas context, KeyEventArgs args) {
            if (args.KeyCode == Keys.Delete) {
                var removed = GetDrawablesInEditState(context);
                RemoveAll(context.Drawables, removed);
                context.State = SelectState.INSTANCE;
            }
        }

        private LinkedList<Drawable> GetDrawablesInEditState(Canvas context) {
            var drawables = new LinkedList<Drawable>();
            foreach (var drawable in context.Drawables)
                if (drawable.State == EditState.INSTANCE)
                    drawables.AddLast(drawable);
            return drawables;
        }

        private void RemoveAll(LinkedList<Drawable> sourceList, LinkedList<Drawable> removedList) {
            foreach (var removed in removedList)
                sourceList.Remove(removed);
        }
    }
}
