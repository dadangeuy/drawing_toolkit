using System.Drawing;
using Drawing_Toolkit.model.drawable.shape;

namespace Drawing_Toolkit.model.drawable.state {
    internal abstract class DrawingState {
        public virtual void Render(IShape shape) { }
        public virtual void Move(IShape shape, Point offset) { }
        public virtual void Resize(IShape shape, Point from, Point to) { }
    }
}