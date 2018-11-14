using System.Drawing;
using Drawing_Toolkit.common;
using Drawing_Toolkit.model.drawable.state;

namespace Drawing_Toolkit.model.drawable {
    internal abstract class Drawable : StateContext<DrawingState> {
        protected Drawable() : base(EditState.INSTANCE) { }

        public virtual void ConnectFromPointWith(Drawable drawable) { }
        public virtual void ConnectToPointWith(Drawable drawable) { }
        public abstract bool Intersect(Point location);
        public abstract bool Intersect(Rectangle area);
        public abstract void Move(Point offset);
        public abstract void Resize(Point from, Point to);
        public abstract void Render(Graphics graphics);
    }

    internal delegate void OnMoveEventHandler(Drawable sender, Point offset);
}