namespace Drawing_Toolkit.Common {
    abstract class StateContext<T> {
        public virtual T State { get; set; }

        public StateContext(T defaultState) {
            State = defaultState;
        }
    }
}
