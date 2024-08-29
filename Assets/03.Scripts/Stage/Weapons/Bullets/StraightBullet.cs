using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using DG.Tweening;
using Stage;
/// <summary> 적중시 1회만 피해를 주는 직사투사체 공격 </summary>
/// <remarks>
///
/// </remarks>
public class StraightBullet : Bullet
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

    //~ For Funcs ~//

    /******* INTERFACE IMPLEMENT *******/
    protected override void SetMoveType()
    {
        BulletMoveType = gameObject.AddComponent<StraightBulletMove>();
    }

    protected override void SetStrategies()
    {
        OnAttackEnter = gameObject.AddComponent<DestroyOnEnter>();
    }

    public override void Initiate()
    {
        DestroyOnEnter doe_config = OnAttackEnter as DestroyOnEnter;
        doe_config.Attack = this;
        doe_config.Damage = Damage;
        doe_config.Pierce = Pierce;

        StraightBulletMove sbm_config = BulletMoveType as StraightBulletMove;
        sbm_config.BulletSpeed = speed;
        sbm_config.weaponPosition = AttackInfo.Weapon.transform.position;
    }

    /******* METHOD *******/
    //~ External ~//
    public void SetProperties(Property property)
    {
        damage = property.Damage;
        pierce = property.Pierce;
        speed = property.Speed;
    }
}