namespace Drawing_Toolkit.common {
    internal abstract class StateContext<T> {
        protected StateContext(T defaultState) {
            State = defaultState;
        }

        public virtual T State { get; set; }
    }
}