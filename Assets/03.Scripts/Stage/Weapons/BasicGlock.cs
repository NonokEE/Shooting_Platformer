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
    public class SpawnAttack : MonoBehaviour, ILeftDown, ILeftHold
    {
        //~~ Interface ~~//
        public float Cooltime;
        private bool isReady = true;

        public Attack Prefab;
        public AttackInfo Info;
        public Action<Attack> SpawnCallback = (inst) => {};

        void ILeftDown.Invoke(){BasicSpawnAttack();}
        void ILeftHold.Invoke(){BasicSpawnAttack();}

        //~~ Logic ~~//
        /// <summary>
        /// 
        /// </summary>
        private void BasicSpawnAttack()
        {
            if (Cooltime == 0 || isReady)
            {
                isReady = false;
                Attack inst = Instantiate(Prefab);
                inst.AttackInfo = Info;
                SpawnCallback(inst);
                StartCoroutine(Cooldown(Cooltime));
            }
        }

        private IEnumerator Cooldown(float time)
        {
            yield return new WaitForSeconds(time);
            Debug.Log("Ready");
            isReady = true;
        }
    }
}