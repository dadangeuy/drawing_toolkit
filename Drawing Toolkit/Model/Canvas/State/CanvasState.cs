using System.Drawing;
using System.Windows.Forms;

namespace Drawing_Toolkit.Model.Canvas.State {
    abstract class CanvasState {
        public virtual void KeyDown(CanvasContext context, KeyEventArgs args) { }
        public virtual void KeyUp(CanvasContext context, KeyEventArgs args) { }
        public virtual void MouseDown(CanvasContext context, MouseEventArgs args) { }
        public virtual void MouseMove(CanvasContext context, MouseEventArgs args) { }
        public virtual void MouseUp(CanvasContext context, MouseEventArgs args) { }
    }
}
