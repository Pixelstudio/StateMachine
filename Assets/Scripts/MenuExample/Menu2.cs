using UnityEngine;

public class Menu2 : State<MenuBase>
{

    public override void EnterState()
    {
        Debug.Log("Entering menu 2 state");
    }

    public override void InState()
    {
        if (GUILayout.Button("Goto menu 1"))
            StateMachine.SetState<Menu1>();
    }

    public override void ExitState()
    {
        Debug.Log("Exiting menu2 state");
    }
}