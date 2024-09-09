using UnityEngine;
using DG.Tweening;

namespace Stage
{
    /// <summary> 지형, 적과 접촉시 튕겨지는 곡사투사체 공격 </summary>
    /// <remarks> 
    /// Collider2D에 알맞은 PhysicsMaterial을 사용해줘야 함. PhysicsMaterial은 Scriptable Object이기 때문에 각 투사체마다 개별로 생성필요.
    /// </remarks>
    public class ThrowerBullet : Bullet
    {
        /// Bullet의 PierceGround와 PierceEnemy가 Thrower에서는 다르게 적용됨
        /// PierceEnemy  -> EnemyBounce: 적에게만 적용되는 튕기기 횟수
        /// PierceGround -> TotalBounce: 콜라이더에 튕길 수 있는 총 횟수 
        protected override void SetMoveType()
        {
            BulletMoveType = gameObject.AddComponent<ThrowerMove>();
        }

        protected override void SetAttackStrategies() {}
        private void OnCollisionEnter2D(Collision2D other) 
        {
            if(other.gameObject.CompareTag("Enemy")) other.gameObject.GetComponent<CharacterLegacy>().Hit(this, Damage);
        }

        public override void Initiate()
        {
            ThrowerMove thm_config = BulletMoveType as ThrowerMove;
            thm_config.Force = Speed;
            thm_config.EnemyBounce = PierceEnemy;
            thm_config.TotalBounce = PierceGround;
            thm_config.OnDestroyCallback += () => {maxDurationTween.Kill();};
        }
    }
}