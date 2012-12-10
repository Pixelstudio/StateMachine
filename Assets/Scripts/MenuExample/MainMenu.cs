using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private StateMachine<MenuBase> stateMachine;
 
    void Start()
    {
        stateMachine = new StateMachine<MenuBase>( new Menu1() ) ;
    }

    void OnGUI()
    {
        stateMachine.InState();
    }

}