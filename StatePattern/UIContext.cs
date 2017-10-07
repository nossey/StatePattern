using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class UIContext : StateContext
    {
        public void onInput(string str)
        {
            if (CurrentState != null && CurrentState is UIState)
                (CurrentState as UIState).InputEvent(str);
        }
    }
}
