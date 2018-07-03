using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class InputState : State
    {
        public delegate void OnInputEvent(string str);
        public OnInputEvent InputEvent;

        public InputState(InputContext context) : base(context)
        {
            if (context == null)
                throw new ArgumentNullException();
            Context.AddState(this);
        }
    }
}