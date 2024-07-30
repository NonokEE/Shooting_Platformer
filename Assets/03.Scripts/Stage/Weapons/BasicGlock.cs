using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Unity.VisualScripting;

using Stage;
using System.Buffers;

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public class BasicGlock : Weapon
{
    /******* FIELD *******/
    //~ Properties ~//
    [Header("Basic Glock Properties")]
    [SerializeField] private SingleBullet leftDownPrefab;
    public int LeftDownDamage;
    public int LeftDownPierce;
    public int LeftDownSpeed;

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
        config.Prefab = leftDownPrefab;
        config.Info = Info;
        config.SpawnCallback += (inst) => 
        {
            SingleBullet bullet = inst as SingleBullet;
            bullet.SetProperties(new SingleBullet.Property(LeftDownDamage, LeftDownPierce, LeftDownSpeed));
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

namespace Stage
{
    public class SpawnAttack : MonoBehaviour, ILeftDown 
    {
        public Attack Prefab;
        public AttackInfo Info;
        public Action<Attack> SpawnCallback = (inst) => {};

        void ILeftDown.Invoke()
        {
            Attack inst = Instantiate(Prefab);
            inst.AttackInfo = Info;
            SpawnCallback(inst); 
        }
    }
}