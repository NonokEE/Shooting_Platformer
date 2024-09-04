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
    [SerializeField] private RectTransform content;

    //~ Bindings ~//

    //~ For Funcs ~//

    //~ Delegate & Event ~//

    //~ Debug ~//

    /******* EVENT FUNC *******/
    private void Start()
    {
        content.gameObject.SetActive(false);        

        Singleton<GameManager>.Inst.StateMachine.AddEvent(GameManager.GameState.GamePause, FiniteStateMachine<GameManager, GameManager.GameState>.EventType.Enter, EnterPause);
        Singleton<GameManager>.Inst.StateMachine.AddEvent(GameManager.GameState.GamePause, FiniteStateMachine<GameManager, GameManager.GameState>.EventType.Exit, ExitPause);
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
        Debug.Log("Panel: Enter Pause"); content.gameObject.SetActive(true);
    }
    private void ExitPause()
    {
        Debug.Log("Panel: Exit  Pause"); content.gameObject.SetActive(false);
    }

    //~ Event Listener ~//

    //~ External ~//
}