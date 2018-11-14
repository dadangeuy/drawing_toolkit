using System;
using System.Collections.Generic;
using System.Drawing;
using Drawing_Toolkit.common;
using Drawing_Toolkit.model.drawable.state;

namespace Drawing_Toolkit.model.drawable {
<<<<<<< HEAD
    internal abstract class Drawable : StateContext<DrawingState> {
        protected readonly LinkedList<IObserver<Point>> MoveObservers = new LinkedList<IObserver<Point>>();
=======
    abstract class Drawable : StateContext<DrawingState> {
        public event OnMoveEventHandler OnMove;
>>>>>>> parent of 3ad424b... Fix Warning

        protected Drawable() : base(EditState.INSTANCE) { }

        public void Move(Point offset) {
            MoveInternal(offset);
            foreach (var observer in MoveObservers) observer.OnNext(offset);
        }

        public virtual void ConnectFromPointWith(Drawable drawable) { }
        public virtual void ConnectToPointWith(Drawable drawable) { }
        public abstract bool Intersect(Point location);
        public abstract bool Intersect(Rectangle area);
        protected abstract void MoveInternal(Point offset);
        public abstract void Resize(Point from, Point to);
        public abstract void Render(Graphics graphics);

<<<<<<< HEAD
        public IDisposable SubscribeMove(IObserver<Point> observer) {
            MoveObservers.AddLast(observer);
            return new Disposable<Point>(MoveObservers, observer);
        }
    }
=======
    delegate void OnMoveEventHandler(Drawable sender, Point offset);
>>>>>>> parent of 3ad424b... Fix Warning
}