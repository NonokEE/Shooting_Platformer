using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public class IngamePanel : MonoBehaviour
{
    /******* FIELD *******/
    //~ Properties ~//

    //~ Bindings ~//

    //~ For Funcs ~//

    //~ Delegate & Event ~//

    //~ Debug ~//

    /******* EVENT FUNC *******/
    private void Awake() 
    {
        var fsm = GameManager.Inst.fsm;

        fsm.AddEvent(GameManager.GameState.Pause, FiniteStateMachine<GameManager, GameManager.GameState>.EventType.Enter, EnterPause);
        fsm.AddEvent(GameManager.GameState.Pause, FiniteStateMachine<GameManager, GameManager.GameState>.EventType.Exit, ExitPause);
    }

    /******* INTERFACE IMPLEMENT *******/

    /******* METHOD *******/
    //~ Internal ~//
    /// <summary> Summary </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <param name="paraName"> param description </param>
    /// <returns>  </returns>
    ///
    private void EnterPause()
    {
        Debug.Log("Panel: Enter Pause"); gameObject.SetActive(true);
    }
    private void ExitPause()
    {
        Debug.Log("Panel: Exit  Pause"); gameObject.SetActive(false);
    }

    //~ Event Listener ~//

    //~ External ~//
}