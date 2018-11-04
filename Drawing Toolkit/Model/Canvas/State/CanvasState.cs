using System.Drawing;
using System.Windows.Forms;

namespace Drawing_Toolkit.Model.Canvas.State {
    abstract class CanvasState {
        public virtual void MouseDown(CanvasContext context, Point location) { }
        public virtual void MouseMove(CanvasContext context, Point location) { }
        public virtual void MouseUp(CanvasContext context, Point location) { }
        public virtual void KeyDown(CanvasContext context, KeyEventArgs args) { }
        public virtual void KeyUp(CanvasContext context, KeyEventArgs args) { }
    }
}
