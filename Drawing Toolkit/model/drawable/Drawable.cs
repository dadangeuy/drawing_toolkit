using System.Drawing;
using Drawing_Toolkit.common;
using Drawing_Toolkit.model.drawable.state;

namespace Drawing_Toolkit.model.drawable {
    abstract class Drawable : StateContext<DrawingState> {
        public event OnMoveEventHandler OnMove;

        protected Drawable() : base(EditState.INSTANCE) { }

        public void Move(Point offset) {
            MoveInternal(offset);
            OnMove?.Invoke(this, offset);
        }

        public abstract bool Intersect(Point location);
        public abstract bool Intersect(Rectangle area);
        protected abstract void MoveInternal(Point offset);
        public abstract void Resize(Point from, Point to);
        public abstract void Render(Graphics graphics);
    }

    delegate void OnMoveEventHandler(Drawable sender, Point offset);
}