using UnityEngine;
using Stage;

public class LeftHoldWeapon : Weapon
{
    /******* FIELD *******/
    //~ Properties ~//
    [Header("Left Hold Properties")]
    [SerializeField] private StraightBullet leftHoldPrefab;
    public int LeftHoldDamage;
    public int LeftHoldSpeed;
    public float LeftHoldBps;

    /******* INTERFACE IMPLEMENT *******/
    protected override void SetStrategies()
    {
        //Set Info
        Info.Weapon = this;

        //Set LeftHold - SpawnAttack<>
        OnLeftHold = gameObject.AddComponent<SpawnAttack>();
    }

    public override void Initiate()
    {
        var config = OnLeftHold as SpawnAttack;
        
        config.Cooltime = 1/LeftHoldBps;

        config.AttackPrefab = leftHoldPrefab;
        config.AttackInfo = Info;
        config.SpawnCallback += (inst) => 
        {
            Bullet bullet = inst as Bullet;

            bullet.Damage = LeftHoldDamage;
            bullet.Speed = LeftHoldSpeed;
            
            bullet.Initiate();
        };
    }
}