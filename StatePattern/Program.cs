using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // var context = new Context<UIState>();
            // var state0 = new UIState();
            //

            var context = new UIContext();
            var state0 = new UIState(context);
            var state1 = new UIState(context);
            state0.EnterEvent = () =>
            {
                Console.WriteLine("Hello form state0!");
            };
            state0.ExitEvent = () =>
            {
                Console.WriteLine("Bye form state0!");
            };
            state0.InputEvent = (s) =>
            {
                if (s == "T")
                    state0.Context.transitState(state1);
            };
            state1.EnterEvent = () =>
            {
                Console.WriteLine("Hello form state1!");
            };
            state1.ExitEvent = () =>
            {
                Console.WriteLine("Bye form state1!");
            };
            state1.InputEvent = (s) =>
            {
                if (s == "T")
                    state1.Context.transitState(state0);
            };
            context.setCurrentState(state0);

            string str = "";
            UIState LastState = null;
            while (true)
            {
                str = Console.ReadLine();
                if (str == "Q")
                {
                    LastState = context.CurrentState as UIState;
                    break;
                }
                context.onInput(str);
            }

            context.transitState(LastState);
            while (true)
            {
                str = Console.ReadLine();
                if (str == "Q")
                {
                    break;
                }
                context.onInput(str);
            }
        }
    }
}