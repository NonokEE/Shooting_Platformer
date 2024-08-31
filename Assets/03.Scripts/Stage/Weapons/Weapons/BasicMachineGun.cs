using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Stage;

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
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


    //~ Bindings ~//

    //~ For Funcs ~//

    //~ Delegate & Event ~//

    //~ Debug ~//

    /******* EVENT FUNC *******/

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
            StraightBullet bullet = inst as StraightBullet;
            bullet.SetProperties(new StraightBullet.Property(LeftHoldDamage, LeftHoldPierce, LeftHoldSpeed));
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