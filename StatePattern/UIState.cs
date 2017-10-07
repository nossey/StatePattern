using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class UIState : State
    {
        public override StateContext Context
        {
            get
            {
                return _Context;
            }
            set
            {
                if (value is UIContext)
                    _Context = value as UIContext;
            }
        }
        UIContext _Context;

        public delegate void onInputEvent(string str);
        public onInputEvent InputEvent;

        public UIState(StateContext context) : base(context)
        {
            if (!(context is UIContext) || context == null)
                throw new ArgumentException();
            Context = context;
            Context.addState(this);
        }
    }
}