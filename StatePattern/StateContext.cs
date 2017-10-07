using System;
using System.Collections.Generic;
using System.Linq;

namespace StatePattern
{
    public class StateContext
    {
        public List<State> StateList = new List<State>();
        public State CurrentState { get; private set; }

        object Locker = new object();

        public void setCurrentState(State state)
        {
            if (state == null || !StateList.Contains(state))
                return;

            CurrentState = state;
        }

        public void addState(State state)
        {
            if (state == null || StateList.Contains(state))
                return;
            StateList.Add(state);
        }

        public void transitState(State targetState)
        {
            if (targetState == null || !StateList.Contains(targetState))
            {
                return;
            }

            lock (Locker)
            {
                CurrentState?.ExitEvent?.Invoke();
                CurrentState = targetState;
                CurrentState?.EnterEvent?.Invoke();
            }
        }
    }
}