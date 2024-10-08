using UnityEngine;
using DG.Tweening;

namespace Stage
{
    /// <summary> 적중시 1회만 피해를 주는 곡사투사체 공격 </summary>
    public class HowitzerBullet : Bullet
    {
        protected override void SetMoveType()
        {
            BulletMoveType = gameObject.AddComponent<HowitzerMove>();
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
            HowitzerMove hwm_config = BulletMoveType as HowitzerMove;
            hwm_config.Force = Speed;
            hwm_config.PierceGround = PierceGround;
            hwm_config.PierceEnemy = PierceEnemy;
            hwm_config.OnDestroyCallback += () => {maxDurationTween.Kill();};
        }
    }
}
