using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Stage;

[RequireComponent(typeof(HitBox))]
/// <summary>체력을 가지고 피해를 받을 수 있는 개체. </summary>
public class Character : MonoBehaviour, IKillable, IStageObject
{
    /******* FIELD *******/
    //~ Killable ~//
    [Header("Killable Attributes")]
    [SerializeField] private int currentHp;
    public int CurrentHp { get{ return currentHp; } }

    [Tooltip("Invincible if maxHP < 0")]
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
    public void Hit(Attack attack, int damage)
    {
        Debug.Log("("+ name + ") got ("+ damage + ")damage by (" + attack.AttackInfo.Attacker.name + ") with (" + attack.AttackInfo.Weapon.name + ")");
        //TODO Attack 피드백
        if(maxHp > 0)
        {
            currentHp -= damage;
            if(currentHp <= 0) Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}