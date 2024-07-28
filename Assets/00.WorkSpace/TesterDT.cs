using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using DG.Tweening;

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public class TesterDT : MonoBehaviour
{
    /******* FIELD *******/
    //~ Properties ~//

    //~ Bindings ~//

    //~ For Funcs ~//
    private float a = 0f;
    private float leg = 0f;

    //~ Delegate & Event ~//

    //~ Debug ~//

    /******* EVENT FUNC *******/
    private void Awake() 
    {
        transform.DOMove(Vector3.left, 1).From();
    }

    private void Update() 
    {
        
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

    //~ Event Listener ~//

    //~ External ~//
}