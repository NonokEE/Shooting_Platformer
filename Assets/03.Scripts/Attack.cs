using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Collider2D))]

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public class Attack : MonoBehaviour
{
    /******* FIELD *******/
    //~ Properties ~//
    [Header("Attack Attributes")]
    [SerializeField] private Character attacker;
    public Character Attacker { get{ return attacker; } }

    //Temp Value//
    public int DamageValue = 10;

    //~ Bindings ~//
    private Collider2D col;
    
    //~ For Funcs ~//

    //~ Delegate & Event ~//

    //~ Debug ~//

    /******* EVENT FUNC *******/
    private void Awake() 
    {
        col = GetComponent<Collider2D>();
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