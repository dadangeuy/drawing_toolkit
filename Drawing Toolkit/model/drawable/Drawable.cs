using System.Drawing;
using Drawing_Toolkit.common;
using Drawing_Toolkit.model.drawable.state;

namespace Drawing_Toolkit.model.drawable {
    internal abstract class Drawable : StateContext<DrawingState> {
        public Drawable() : base(EditState.INSTANCE) { }

        public abstract bool Intersect(Point location);
        public abstract bool Intersect(Rectangle area);
        public abstract void Move(Point offset);
        public abstract void Resize(Point from, Point to);
        public abstract void Render(Graphics graphics);
    }
}