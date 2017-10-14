using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class InputContext : StateContext
    {
        public void onInput(string str)
        {
            if (CurrentState != null && CurrentState is InputState)
                (CurrentState as InputState).InputEvent(str);
        }
    }
}
