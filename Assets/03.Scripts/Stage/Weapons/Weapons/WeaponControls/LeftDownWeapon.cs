using UnityEngine;
using Stage;

public class LeftDownWeapon : Weapon
{
    /******* FIELD *******/
    //~ Properties ~//
    [Header("LeftDown Properties")]
    [SerializeField] private Bullet leftDownPrefab;
    public int LeftDownDamage;
    public int LeftDownSpeed;
    public float LeftDownBps;

    /******* INTERFACE IMPLEMENT *******/
    protected override void SetStrategies()
    {
        //Set Info
        Info.Weapon = this;

        //Set LeftDown - SpawnAttack<>
        OnLeftDown = gameObject.AddComponent<SpawnAttack>();
    }

    public override void Initiate()
    {
        var config = OnLeftDown as SpawnAttack;

        config.Cooltime = 1/LeftDownBps;

        config.AttackPrefab = leftDownPrefab;
        config.AttackInfo = Info;
        config.SpawnCallback += (inst) => 
        {
            Bullet bullet = inst as Bullet;

            bullet.Damage = LeftDownDamage;
            bullet.Speed = LeftDownSpeed;
            
            bullet.Initiate();
        };
    }
}
