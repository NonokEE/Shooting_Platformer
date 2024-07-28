using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using PlayerStrategy.PlayerWeapon;

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public class BasicGlock : PlayerWeapon
{
    /******* FIELD *******/
    //~ Properties ~//

    //~ Bindings ~//

    //~ For Funcs ~//

    //~ Delegate & Event ~//

    //~ Debug ~//

    /******* EVENT FUNC *******/

    /******* INTERFACE IMPLEMENT *******/
    protected override void Initiate()
    {
        leftDown = new BasicGlockLeftDown();
    }

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

public class BasicGlockLeftDown : ILeftDown
{
    public void Trigger()
    {
        Debug.Log("Basic Glock Left Down");
    }
}
