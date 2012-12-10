
public abstract class State<T>
{
    protected StateMachine<T> StateMachine;

    public void SetMachine (StateMachine<T> stateMachine)
    {
        this.StateMachine = stateMachine;
    }

    public abstract void EnterState();

    public abstract void InState();
    
    public abstract void ExitState();

}
