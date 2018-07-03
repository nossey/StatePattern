using System;
using System.Collections.Generic;
using System.Linq;

namespace StatePattern
{
    public class StateContext
    {
        public List<State> StateList = new List<State>();
        public State CurrentState { get; private set; }

        // Allow transit to self state
        public bool SelfTransit { get; set; } = true;

        object Locker { get; set; } = new object();

        public void SetCurrentState(State state)
        {
            if (state == null || !StateList.Contains(state))
                return;

            CurrentState = state;
        }

        public void AddState(State state)
        {
            if (state == null || StateList.Contains(state))
                return;
            StateList.Add(state);
        }

        public void TransitState(State targetState)
        {
            if (targetState == null || (!StateList.Contains(targetState)))
            {
                return;
            }

            lock (Locker)
            {
                CurrentState?.OnExit();
                CurrentState = targetState;
                CurrentState?.OnEnter();
            }
        }
    }
}