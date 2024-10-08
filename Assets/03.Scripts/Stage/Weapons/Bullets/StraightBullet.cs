using UnityEngine;
using DG.Tweening;

namespace Stage
{
    /// <summary> 적중시 1회만 피해를 주는 직사투사체 공격 </summary>
    public class StraightBullet : Bullet
    {
        protected override void SetMoveType()
        {
            BulletMoveType = gameObject.AddComponent<StraightMove>();
        }

        protected override void SetAttackStrategies()
        {
            OnAttackEnter = gameObject.AddComponent<HitOnEnter>();
        }

        public override void Initiate()
        {
            HitOnEnter hoe_config = OnAttackEnter as HitOnEnter;
            hoe_config.Attack = this;
            hoe_config.Damage = Damage;

            BulletMoveType.Bullet = this;
            StraightMove sbm_config = BulletMoveType as StraightMove;
            sbm_config.BulletSpeed = Speed;
            sbm_config.PierceGround = PierceGround;
            sbm_config.PierceEnemy = PierceEnemy;
            sbm_config.OnDestroyCallback += () => {maxDurationTween.Kill();};
        }
    }
}