using Drawing_Toolkit.Model.Drawing.Shape;
using System.Drawing;

namespace Drawing_Toolkit.Model.Drawing.State {
    abstract class DrawingState {
        public virtual void Render(IShape shape) { }
        public virtual void Move(IShape shape, Point offset) { }
        public virtual void Resize(IShape shape, Point from, Point to) { }
    }
}
