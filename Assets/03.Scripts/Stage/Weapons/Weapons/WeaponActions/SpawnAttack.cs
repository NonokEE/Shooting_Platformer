using System;
using System.Collections;

using UnityEngine;
using DG.Tweening;

namespace Stage
{
    public class SpawnAttack : WeaponAction, ILeftDown, ILeftHold
    {
        //~~ Interface ~~//
        public float Cooltime;
        private bool isReady = true;
        private Tween cooldownTween;

        void ILeftDown.Invoke(){BasicSpawnAttack();}
        void ILeftHold.Invoke(){BasicSpawnAttack();}

        private void BasicSpawnAttack()
        {
            if(isReady)
            {
                isReady = false;

                Attack inst = Instantiate(AttackPrefab);
                inst.AttackInfo = attackInfo;
                SpawnCallback(inst);
                
                float timer = Cooltime;
                cooldownTween = DOTween.To(() => timer, x => timer = x, 0, Cooltime).OnComplete(() => { timer = Cooltime ; isReady = true;});
            }
        }

        private void OnDestroy() 
        {
            cooldownTween.Kill();
        }
    }
}