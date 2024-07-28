using System.Collections;
using System.Collections.Generic;
using Stage;
using UnityEngine;

[RequireComponent(typeof(HitBox))]
/// <summary>체력을 가지고 피해를 받을 수 있는 개체. </summary>
public class Character : MonoBehaviour, IKillable, IStageObject
{
    /******* FIELD *******/
    //~ Killable ~//
    [Header("Killable Attributes")]
    [SerializeField] private int currentHp;
    public int CurrentHp { get{ return currentHp; } }

    [SerializeField] private int maxHp;
    public int MaxHp { get {return maxHp; } }

    //~ StageObject ~//
    private HitBox hitBox;
    public HitBox Hitbox { get {return hitBox; } }

    //~ Bindings ~//

    //~ For Funcs ~//

    //~ Delegate & Event ~//

    //~ Debug ~//

    /******* EVENT FUNC *******/
    protected void Awake() 
    {
        hitBox = GetComponent<HitBox>();
    }

    protected void Start() 
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
        Debug.Log(name + " got damaged by " + attack.Attacker.name);
        currentHp -= attack.DamageValue;
    }
}