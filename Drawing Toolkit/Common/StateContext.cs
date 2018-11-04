namespace Drawing_Toolkit.Common {
    abstract class StateContext<T> {
        public T State { get; set; }

        public StateContext(T defaultState) {
            State = defaultState;
        }
    }
}
