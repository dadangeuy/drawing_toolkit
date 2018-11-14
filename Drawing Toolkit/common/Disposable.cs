using System;
using System.Collections.Generic;

namespace Drawing_Toolkit.common {
    class Disposable<T> : IDisposable {
        private readonly LinkedList<IObserver<T>> observers;
        private readonly IObserver<T> observer;

        public Disposable(LinkedList<IObserver<T>> observers, IObserver<T> observer) {
            this.observers = observers;
            this.observer = observer;
        }

        public void Dispose() {
            if (observer != null && observers.Contains(observer))
                observers.Remove(observer);
        }
    }
}
