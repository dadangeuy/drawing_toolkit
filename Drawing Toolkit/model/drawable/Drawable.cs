using System;
using System.Collections.Generic;
using System.Drawing;
using Drawing_Toolkit.common;
using Drawing_Toolkit.model.drawable.state;

namespace Drawing_Toolkit.model.drawable {
    internal abstract class Drawable : StateContext<DrawingState>, IObservable<Drawable> {
        private readonly LinkedList<IObserver<Drawable>> Observers = new LinkedList<IObserver<Drawable>>();

        protected Drawable() : base(EditState.INSTANCE) { }

        public abstract bool Intersect(Point location);
        public abstract bool Intersect(Rectangle area);
        public abstract void Move(Point offset);
        public abstract void Resize(Point from, Point to);
        public abstract void Render(Graphics graphics);

        protected void notifyUpdate() {
            foreach (var observer in Observers) observer.OnNext(this);
        }

        public IDisposable Subscribe(IObserver<Drawable> observer) {
            Observers.AddLast(observer);
            return new Disposable<Drawable>(Observers, observer);
        }
    }
}