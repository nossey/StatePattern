using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public abstract class State
    {
        public abstract StateContext Context
        {
            get;
            set;
        }

        public delegate void stateEnterEvent();
        public stateEnterEvent EnterEvent;

        public delegate void stateExitEvent();
        public stateEnterEvent ExitEvent;

        public State(StateContext context)
        {
            Context = context;
        }
    }
}
