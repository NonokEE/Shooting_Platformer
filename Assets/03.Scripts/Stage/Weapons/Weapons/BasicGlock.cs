using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

/// <summary> 단발 탄환 발사하는 기본 권총 </summary>
/// <remarks>
/// 좌클릭 : 탄환 발사
/// </remarks>
/// 
namespace Stage
{
    public class BasicGlock : Weapon
    {
        [Header("BasicGlock Properties")]
        public Bullet BulletPrefab;

        [Space]
        public int BulletDamage;
        public int BulletSpeed;
        public float Bps;

        [Space]
        public int PierceEnemy;
        public int PierceGround;

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

                bullet.PierceEnemy = PierceEnemy;
                bullet.PierceGround = PierceGround;
                
                bullet.Initiate();
            };
        }
    }
}