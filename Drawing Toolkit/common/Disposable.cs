using System;
using System.Collections.Generic;

namespace Drawing_Toolkit.common {
    class Disposable<T> : IDisposable {
        private readonly LinkedList<IObserver<T>> Observers;
        private readonly IObserver<T> Observer;

        public Disposable(LinkedList<IObserver<T>> observers, IObserver<T> observer) {
            this.Observers = observers;
            this.Observer = observer;
        }

        public void Dispose() {
            if (Observer != null && Observers.Contains(Observer))
                Observers.Remove(Observer);
        }
    }
}
