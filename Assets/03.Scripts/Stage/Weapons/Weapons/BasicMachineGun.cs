using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary> 탄환연발하는 기본 기관총 </summary>
/// <remarks>
/// 좌클릭 유지 : 탄환 발사
/// </remarks>
/// 
namespace Stage
{
    public class BasicMachineGun : Weapon
    {
        [Header("BasicMachineGun Properties")]
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
            OnLeftHold = gameObject.AddComponent<SpawnAttack>();
        }

        public override void Initiate()
        {
            var config = OnLeftHold as SpawnAttack;

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