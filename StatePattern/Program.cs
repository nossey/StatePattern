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
            var context = new InputContext();
            var state0 = new InputState(context);
            var state1 = new InputState(context);
            state0.OnEnter += () =>
            {
                Console.WriteLine("Hello form state0!");
            };
            state0.OnExit += () =>
            {
                Console.WriteLine("Bye form state0!");
            };
            state0.InputEvent = (s) =>
            {
                if (s == "T")
                    state0.Context.transitState(state1);
            };
            state1.OnEnter += () =>
            {
                Console.WriteLine("Hello form state1!");
            };
            state1.OnExit += () =>
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
            InputState LastState = null;
            while (true)
            {
                str = Console.ReadLine();
                if (str == "Q")
                {
                    LastState = context.CurrentState as InputState;
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