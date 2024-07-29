using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Unity.VisualScripting;

using Stage;

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public class BasicGlock : Weapon
{

    /******* FIELD *******/
    //~ Properties ~//

    //~ Bindings ~//
    [SerializeField] private Attack leftAttack;

    //~ For Funcs ~//

    //~ Delegate & Event ~//

    //~ Debug ~//

    /******* EVENT FUNC *******/
    
    /******* INTERFACE IMPLEMENT *******/
    private void Awake()
    {
        leftAttack = Resources.Load("Weapon/NormalBullet").AddComponent<Attack>();

        OnLeftDown += (Owner) => { LeftDown(); };
    }
    

    /******* METHOD *******/
    //~ Internal ~//
    /// <summary> Summary </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <param name="paraName"> param description </param>
    /// <returns>  </returns>
    private void LeftDown()
    {
        Instantiate(leftAttack, transform.position, transform.rotation);
    }

    //~ Event Listener ~//

    //~ External ~//
}