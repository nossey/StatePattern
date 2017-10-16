# State pattern sample
This project demonstrates a minimum state-pattern.

## State
State class 

```csharp
public class State
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
```

"OnEnter" & "OnExit" are automatically executed when you  enter or leave a state.

## StateContext
StateContext class has a State list and manages current state & state transition.
```csharp
public class StateContext
{
    public List<State> StateList = new List<State>();
    public State CurrentState { get; private set; }

    // Allow transit to self state
    public bool SelfTransit = true;

    object Locker = new object();

    public void setCurrentState(State state)
    {
        if (state == null || !StateList.Contains(state))
            return;

        CurrentState = state;
    }

    public void addState(State state)
    {
        if (state == null || StateList.Contains(state))
            return;
        StateList.Add(state);
    }

    public void transitState(State targetState)
    {
        if (targetState == null || (StateList.Contains(targetState) && SelfTransit))
        {
            return;
        }

        lock (Locker)
        {
            CurrentState?.OnExit();
            CurrentState = targetState;
            CurrentState?.OnEnter();
        }
    }
}
```

## Example
The same examlple is shown in Program.cs.

```csharp

// State class
public class InputState : State
{
    public delegate void onInputEvent(string str);
    public onInputEvent InputEvent;

    public InputState(InputContext context) : base(context)
    {
        if (context == null)
            throw new ArgumentNullException();
        Context.addState(this);
    }
}
...

// Context class
public class InputContext : StateContext
{
    public void onInput(string str)
    {
        if (CurrentState != null && CurrentState is InputState)
            (CurrentState as InputState).InputEvent(str);
    }
}
...

// State construction
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

// State transition test
while (true)
{
    str = Console.ReadLine();
    if (str == "Q")
    {
        break;
    }
    context.onInput(str);
}
```