using System.Drawing;

namespace Drawing_Toolkit.Model.Canvas.State {
    abstract class CanvasState {
        public virtual void MouseDown(CanvasContext context, Point location) { }
        public virtual void MouseMove(CanvasContext context, Point location) { }
        public virtual void MouseUp(CanvasContext context, Point location) { }
    }
}
