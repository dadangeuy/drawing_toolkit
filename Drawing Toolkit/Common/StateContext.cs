namespace Drawing_Toolkit.common {
    internal abstract class StateContext<T> {
        public StateContext(T defaultState) {
            State = defaultState;
        }

        public virtual T State { get; set; }
    }
}