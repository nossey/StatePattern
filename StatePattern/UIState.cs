using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class UIState : State
    {
        public delegate void onInputEvent(string str);
        public onInputEvent InputEvent;

        public UIState(UIContext context) : base(context)
        {
            if (context == null)
                throw new ArgumentNullException();
            Context.addState(this);
        }
    }
}