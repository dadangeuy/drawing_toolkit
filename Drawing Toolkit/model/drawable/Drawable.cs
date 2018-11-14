using System;
using System.Collections.Generic;
using System.Drawing;
using Drawing_Toolkit.common;
using Drawing_Toolkit.model.drawable.state;

namespace Drawing_Toolkit.model.drawable {
    internal abstract class Drawable : StateContext<DrawingState> {
        protected readonly LinkedList<IObserver<Point>> MoveObservers = new LinkedList<IObserver<Point>>();
        protected Drawable() : base(EditState.INSTANCE) { }

        public void Move(Point offset) {
            MoveInternal(offset);
            foreach (var observer in MoveObservers) observer.OnNext(offset);
        }

        public abstract bool Intersect(Point location);
        public abstract bool Intersect(Rectangle area);
        protected abstract void MoveInternal(Point offset);
        public abstract void Resize(Point from, Point to);
        public abstract void Render(Graphics graphics);
    }
}