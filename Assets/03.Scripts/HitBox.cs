using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Collider2D))]

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public class HitBox : MonoBehaviour
{
    /******* FIELD *******/
    //~ Properties ~//

    //~ Bindings ~//
    private Character character;
    private Collider2D col;

    //~ For Funcs ~//

    //~ Delegate & Event ~//

    //~ Debug ~//

    /******* EVENT FUNC *******/
    private void Awake() 
    {
        character = transform.GetComponentInParent<Character>();
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Attack"))
        {
            character.Hit(other.GetComponent<Attack>());
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

    //~ Event Listener ~//

    //~ External ~//
}