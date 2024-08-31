using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Stage;

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public class BasicGlock : Weapon
{
    /******* FIELD *******/
    //~ Properties ~//
    [Header("Basic Glock Properties")]
    [SerializeField] private StraightBullet leftDownPrefab;
    public int LeftDownDamage;
    public int LeftDownPierce;
    public int LeftDownSpeed;
    public float LeftDownBps;

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

        //Set LeftDown - SpawnAttack<SingleBullet>
        OnLeftDown = gameObject.AddComponent<SpawnAttack>();
    }

    public override void Initiate()
    {
        var config = OnLeftDown as SpawnAttack;

        config.Cooltime = 1/LeftDownBps;

        config.Prefab = leftDownPrefab;
        config.Info = Info;
        config.SpawnCallback += (inst) => 
        {
            StraightBullet bullet = inst as StraightBullet;
            bullet.SetProperties(new StraightBullet.Property(LeftDownDamage, LeftDownPierce, LeftDownSpeed));
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
