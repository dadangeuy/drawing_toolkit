using Drawing_Toolkit.Common;
using Drawing_Toolkit.Model.Drawing.State;
using System.Drawing;

namespace Drawing_Toolkit.Model.Drawing {
    abstract class DrawingApi : StateContext<DrawingState> {
        public DrawingApi() : base(EditState.INSTANCE) { }
        public abstract bool Intersect(Point location);
        public abstract void Move(Point offset);
        public abstract void Resize(Point from, Point to);
        public abstract void Render(Graphics graphics);
    }
}
