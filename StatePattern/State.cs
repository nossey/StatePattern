using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class State
    {
        public StateContext Context
        {
            get;
            private set;
        }

        public delegate void StateEnterEvent();
        public StateEnterEvent OnEnter { get; set; }

        public delegate void StateExitEvent();
        public StateExitEvent OnExit { get; set; }

        public State(StateContext context)
        {
            Context = context;
        }
    }
}