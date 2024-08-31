using UnityEngine;
using Stage;

public class BasicMachineGun : Weapon
{
    /******* FIELD *******/
    //~ Properties ~//
    [Header("Basic Machine Gun Properties")]
    [SerializeField] private StraightBullet leftHoldPrefab;
    public int LeftHoldDamage;
    public int LeftHoldPierce;
    public int LeftHoldSpeed;
    public float LeftHoldBps;

    /******* INTERFACE IMPLEMENT *******/
    protected override void SetStrategies()
    {
        //Set Info
        Info.Weapon = this;

        //Set LeftHold - SpawnAttack<SingleBullet>
        OnLeftHold = gameObject.AddComponent<SpawnAttack>();
    }

    public override void Initiate()
    {
        var config = OnLeftHold as SpawnAttack;
        
        config.Cooltime = 1/LeftHoldBps;

        config.Prefab = leftHoldPrefab;
        config.Info = Info;
        config.SpawnCallback += (inst) => 
        {
            Bullet bullet = inst as StraightBullet;

            bullet.Damage = LeftHoldDamage;
            bullet.Pierce = LeftHoldPierce;
            bullet.Speed = LeftHoldSpeed;
            
            bullet.Initiate();
        };
    }
    /******* METHOD *******/
    //~ Internal ~//
    /// <summary> Summary </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <param name="paraName"> param description </param>
    /// <returns>  </returns>
    //~ External ~//

    //~ Event Listener ~//

}