using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Drawing_Toolkit.common;
using Drawing_Toolkit.model.canvas.state;
using Drawing_Toolkit.model.drawable;
using Drawing_Toolkit.model.drawable.impl;

namespace Drawing_Toolkit.model.canvas {
    internal class Canvas : StateContext<CanvasState> {
        public Drawable NewDrawable = EmptyDrawable.Instance;
        public LinkedList<Drawable> Drawables { get; } = new LinkedList<Drawable>();
        public Point InitialLocation { get; set; }

        public Canvas() : base(SelectState.Instance) { }

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
            foreach (var drawing in Drawables)
                if (drawing.Intersect(area))
                    drawing.Render(graphics);
        }
    }
}