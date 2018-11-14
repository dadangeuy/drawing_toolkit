using System.Windows.Forms;

namespace Drawing_Toolkit.model.canvas.state {
    internal abstract class CanvasState {
        public virtual void KeyDown(Canvas context, KeyEventArgs args) { }
        public virtual void KeyUp(Canvas context, KeyEventArgs args) { }
        public virtual void MouseDown(Canvas context, MouseEventArgs args) { }
        public virtual void MouseMove(Canvas context, MouseEventArgs args) { }
        public virtual void MouseUp(Canvas context, MouseEventArgs args) { }
    }
}