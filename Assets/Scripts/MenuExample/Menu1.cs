using UnityEngine;

public class Menu1 : State<MenuBase>
{

    public override void EnterState()
    {
        Debug.Log("Entering menu 1 state");
    }

    public override void InState()
    {
        if (GUILayout.Button("Goto menu 2"))
            StateMachine.SetState<Menu2>();
    }

    public override void ExitState()
    {
        Debug.Log("Exiting menu1 state");
    }
}