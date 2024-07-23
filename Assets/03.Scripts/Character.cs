using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Collider2D))]

/// <summary>체력을 가지고 피해를 받을 수 있는 개체</summary>
/// <remarks>
///
/// </remarks>
public class Character : MonoBehaviour
{
    /******* FIELD *******/
    //~ Properties ~//
    [Header("Character Attributes")]
    [SerializeField] private int currentHp;
    public int CurrentHp { get{ return currentHp; } }

    [SerializeField] private int maxHp;
    public int MaxHp { get {return maxHp; } }

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

    private void Start() 
    {
        currentHp = maxHp;
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
    public void Hit(Attack attack)
    {
        Debug.Log(name + " got damaged by " + attack.name);
        currentHp -= attack.DamageValue;
    }
}