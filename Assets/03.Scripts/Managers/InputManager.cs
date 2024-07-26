using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary> Input에 따라 GameManager의 이벤트 발동 </summary>
/// <remarks>
///
/// </remarks>
public class InputManager : MonoBehaviour
{
    /******* FIELD *******/
    //~ Properties ~//

    //~ Bindings ~//

    //~ For Funcs ~//

    //~ Delegate & Event ~//

    //~ Debug ~//

    /******* EVENT FUNC *******/
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.Inst.State == GameManager.GameState.Playing) 
            {
                GameManager.Inst.State = GameManager.GameState.Pause;
            }
            else if (GameManager.Inst.State == GameManager.GameState.Pause)
            {
                GameManager.Inst.State = GameManager.GameState.Playing;
            }
            Debug.Log(GameManager.Inst.State);
        }
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
    

    //~ Event Listener ~//

    //~ External ~//
}