using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Stage;

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public class BasicBullet : Attack
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
        attackEnter += (other) => 
        {
            Character target = other.gameObject.GetComponent<Character>();
            if(target != Attacker)
            {
                target.Hit(this);
                Destroy(gameObject);
            }
        };
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