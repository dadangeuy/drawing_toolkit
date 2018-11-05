using Drawing_Toolkit.Model.Drawing;
using Drawing_Toolkit.Model.Drawing.State;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Drawing_Toolkit.Model.Canvas.State {
    class GroupSelectState : CanvasState {
        public static readonly GroupSelectState INSTANCE = new GroupSelectState();
        private GroupSelectState() { }

        public override void KeyDown(CanvasContext context, KeyEventArgs args) {
            if (args.Control && args.KeyCode == Keys.G) GroupDrawing(context);
        }

        public override void MouseDown(CanvasContext context, MouseEventArgs args) {
            var location = args.Location;
            foreach (var drawing in context.Drawings) {
                if (drawing.Intersect(location)) {
                    drawing.State = EditState.INSTANCE;
                    return;
                }
            }
        }

        private void GroupDrawing(CanvasContext context) {
            var groupDrawingList = new LinkedList<DrawingApi>();
            foreach (var drawing in context.Drawings)
                if (drawing.State == EditState.INSTANCE)
                    groupDrawingList.AddLast(drawing);

            var groupDrawing = new GroupDrawingContext(groupDrawingList);
            context.Drawings.AddLast(groupDrawing);

            foreach (var drawing in groupDrawingList)
                context.Drawings.Remove(drawing);
        }
    }
}
