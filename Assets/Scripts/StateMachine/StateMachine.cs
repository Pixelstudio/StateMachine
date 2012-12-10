using System;
using System.Collections.Generic;

public class StateMachine<T>
{
    public event Action OnStateChanged;

    private readonly Dictionary<Type, State<T>> states = new Dictionary<Type, State<T>>();
    private State<T> currentState;
    
    public StateMachine(State<T> initialState)
    {
        initialState.SetMachine(this);
        states.Add(initialState.GetType(), initialState);
        currentState = initialState;
        initialState.EnterState();
    }

    public void InState()
    {
        if (currentState != null) 
            currentState.InState();
    }

    public void SetState<TR>() where TR : State<T>
    {
        var newState = typeof (TR);
        if (currentState.GetType() == newState)
            return;

        if (currentState != null) 
            currentState.ExitState();

        currentState = GetState(newState);
        currentState.EnterState();

        if (OnStateChanged != null)
            OnStateChanged();
    }

    private State<T> GetState(Type newState)
    {
        if (states.ContainsKey(newState))
            return states[newState];

        var state = Activator.CreateInstance(newState) as State<T>;
        if (state != null)
        {
            state.SetMachine(this);
            states.Add(newState, state);
            return state;
        }
        return null;
    }
}
