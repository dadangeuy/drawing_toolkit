using System.Drawing;
using Drawing_Toolkit.Model.Drawable.Shape;

namespace Drawing_Toolkit.Model.Drawable.State {
    abstract class DrawingState {
        public virtual void Render(IShape shape) { }
        public virtual void Move(IShape shape, Point offset) { }
        public virtual void Resize(IShape shape, Point from, Point to) { }
    }
}
