using Drawing_Toolkit.Common;
using Drawing_Toolkit.Model.Canvas.State;
using Drawing_Toolkit.Model.Drawing;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Drawing_Toolkit.Model.Canvas {
    class Canvas : StateContext<CanvasState> {
        public LinkedList<Drawable> Drawings { get; } = new LinkedList<Drawable>();
        public Drawable NewDrawing = Drawable.EMPTY;
        public Point InitialLocation { get; set; }

        public Canvas() : base(SelectState.INSTANCE) { }

        public void MouseDown(MouseEventArgs args) {
            State.MouseDown(this, args);
        }

        public void MouseMove(MouseEventArgs args) {
            State.MouseMove(this, args);
        }

        public void MouseUp(MouseEventArgs args) {
            State.MouseUp(this, args);
        }

        public void KeyDown(KeyEventArgs args) {
            State.KeyDown(this, args);
        }

        public void KeyUp(KeyEventArgs args) {
            State.KeyUp(this, args);
        }

        public void Render(Graphics graphics, Rectangle area) {
            foreach (var drawing in Drawings) {
                if (drawing.Intersect(area)) {
                    drawing.Render(graphics);
                }
            }
        }
    }
}
