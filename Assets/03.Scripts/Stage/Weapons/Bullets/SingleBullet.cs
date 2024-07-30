using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using DG.Tweening;
using Stage;
/// <summary> 적중시 1회만 피해를 주는 투사체 공격</summary>
/// <remarks>
///
/// </remarks>
public class SingleBullet : Attack
{
    /******* FIELD *******/
    public class Property
    {
        public Property(int damage, int pierce, int speed)
        {
            Damage = damage;
            Pierce = pierce;
            Speed = speed;
        }
        public int Damage;
        public int Pierce;
        public int Speed;
    }
    //~ Properties ~//
    [Header("SingleBullet Properties")]
    [SerializeField] private int damage;
    public int Damage { get{ return damage; } }
    
    [SerializeField] private int pierce;
    public int Pierce { get { return pierce; } }

    [SerializeField] private int speed;
    public int Speed { get { return speed; } }

    //~ Bindings ~//

    //~ For Funcs ~//
    private Tween moveTween;

    //~ Delegate & Event ~//

    //~ Debug ~//

    /******* EVENT FUNC *******/
    private void Start() 
    {
        transform.position = AttackInfo.Weapon.transform.position;

        var mousePosition = Tools.MousePosition2D();

        Vector2 newPos = mousePosition - transform.position;
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(200, 10);
        moveTween = transform.DOMove(mousePosition, speed).SetEase(Ease.Linear).SetSpeedBased().SetLoops(-1, LoopType.Incremental);
    }

    /******* INTERFACE IMPLEMENT *******/
    protected override void SetStrategies()
    {
        //attackEnter
        OnAttackEnter = gameObject.AddComponent<DestroyOnEnter>();
    }
    public override void Initiate()
    {
        DestroyOnEnter config = OnAttackEnter as DestroyOnEnter;
        config.Attack = this;
        config.Damage = Damage;
        config.Pierce = Pierce;
        config.DestroyCallback += () => { moveTween.Kill(); };
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
    public void SetProperties(Property property)
    {
        damage = property.Damage;
        pierce = property.Pierce;
        speed = property.Speed;
    }

}

namespace Stage
{
    public class DestroyOnEnter : MonoBehaviour, IAttackEnter
    {
        public Attack Attack;
        public int Damage;
        public int Pierce;
        public Action DestroyCallback;

        public void Invoke(Collider2D other)
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                DestroyCallback();
                Destroy(gameObject);
            }
            else if(other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Character>().Hit(Attack, Damage);
                if(Pierce == -1) return;
                if(Pierce > 0) Pierce -= 1;
                if(Pierce == 0) 
                {
                    DestroyCallback();
                    Destroy(gameObject);
                }
            }
        }
    }
}