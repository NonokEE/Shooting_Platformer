using UnityEngine;
using Stage;
using DG.Tweening;

/// <summary> 적중시 1회만 피해를 주는 곡사투사체 공격 </summary>
public class HowitzerBullet : Bullet
{
    [Header("StraightBullet Properties")]
    public int PierceEnemy;
    public int PierceGround;

    protected override void SetMoveType()
    {
        BulletMoveType = gameObject.AddComponent<HowitzerMove>();
    }

    protected override void SetStrategies()
    {
        OnAttackEnter = gameObject.AddComponent<HitOnEnter>();
    }

    public override void Initiate()
    {
        HitOnEnter hoe_config = OnAttackEnter as HitOnEnter;
        hoe_config.Attack = this;
        hoe_config.Damage = Damage;

        HowitzerMove hwm_config = BulletMoveType as HowitzerMove;
        hwm_config.StartPosition = AttackInfo.Weapon.transform.position;
        hwm_config.Force = Speed;
        hwm_config.PierceGround = PierceGround;
        hwm_config.PierceEnemy = PierceEnemy;
        hwm_config.OnDestroyCallback += () => {maxDurationTween.Kill();};
    }
}