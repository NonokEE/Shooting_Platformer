using System;
using System.Collections;

using UnityEngine;

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
                Attack inst = Instantiate(Prefab);
                inst.AttackInfo = Info;
                SpawnCallback(inst);
                if(Cooltime != 0) 
                {
                    isReady = false;
                    StartCoroutine(Cooldown(Cooltime));
                }
            }
        }

        private IEnumerator Cooldown(float time)
        {
            yield return new WaitForSeconds(time);
            isReady = true;
        }
    }
}