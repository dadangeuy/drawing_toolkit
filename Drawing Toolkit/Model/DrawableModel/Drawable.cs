using System.Drawing;
using Drawing_Toolkit.Common;
using Drawing_Toolkit.Model.DrawableModel.State;

namespace Drawing_Toolkit.Model.DrawableModel {
    abstract partial class Drawable : StateContext<DrawingState> {
        public static readonly Drawable EMPTY = new EmptyDrawingContext();

        public Drawable() : base(EditState.INSTANCE) { }

        public abstract bool Intersect(Point location);
        public abstract bool Intersect(Rectangle area);
        public abstract void Move(Point offset);
        public abstract void Resize(Point from, Point to);
        public abstract void Render(Graphics graphics);
    }
}
