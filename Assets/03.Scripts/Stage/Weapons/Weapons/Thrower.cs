using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary> 투척무기 </summary>
/// <remarks>
/// 좌클릭 : 탄환 발사
/// </remarks>
/// 
namespace Stage
{
    public class Thrower : Weapon
    {
        [Header("Thrower Properties")]
        /// 프리팹
        /// 데미지
        /// 초기탄속
        /// BPS
        /// 
        /// 바운드횟수
        /// 유지시간
        /// 
        /// 탄성
        /// 마찰
        public ThrowerBullet BulletPrefab;

        [Space]
        public int BulletDamage;
        public int BulletSpeed;
        public float Bps;

        [Space]
        public int EnemyBounce;
        public int TotalBounce;
        public float BulletDuration;

        //
        protected override void SetStrategies()
        {
            AttackInfo.Weapon = this;
            OnLeftDown = gameObject.AddComponent<SpawnAttack>();
        }

        public override void Initiate()
        {
            var config = OnLeftDown as SpawnAttack;

            config.Cooltime = 1/Bps;

            config.AttackPrefab = BulletPrefab;
            config.AttackInfo = AttackInfo;
            config.SpawnCallback += (inst) => 
            {
                Bullet bullet = inst as Bullet;

                bullet.Damage = BulletDamage;
                bullet.Speed = BulletSpeed;

                bullet.StartPosition = AttackInfo.Attacker.transform.position;
                bullet.TargetPosition = StageTools.MousePosition2D();

                bullet.PierceEnemy = EnemyBounce;
                bullet.PierceGround = TotalBounce;
                bullet.MaxDuration = BulletDuration;
                
                bullet.Initiate();
            };
        }
    }
}