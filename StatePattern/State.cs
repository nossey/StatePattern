using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public abstract class State
    {
        public StateContext Context
        {
            get;
            private set;
        }

        public delegate void stateEnterEvent();
        public stateEnterEvent OnEnter;

        public delegate void stateExitEvent();
        public stateEnterEvent OnExit;

        public State(StateContext context)
        {
            Context = context;
        }
    }
}