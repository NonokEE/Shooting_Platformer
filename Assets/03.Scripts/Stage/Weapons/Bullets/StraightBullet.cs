using UnityEngine;
using Stage;
using DG.Tweening;

/// <summary> 적중시 1회만 피해를 주는 직사투사체 공격 </summary>
public class StraightBullet : Bullet
{
    protected override void SetMoveType()
    {
        BulletMoveType = gameObject.AddComponent<StraightMove>();
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

        StraightMove sbm_config = BulletMoveType as StraightMove;
        sbm_config.StartPosition = AttackInfo.Weapon.transform.position;
        sbm_config.BulletSpeed = Speed;
        sbm_config.PierceGround = PierceGround;
        sbm_config.PierceEnemy = PierceEnemy;
        sbm_config.OnDestroyCallback += () => {maxDurationTween.Kill();};
    }
}