using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Stage
{
    public class WeaponAction : MonoBehaviour
    {
        public Attack AttackPrefab { get => attackPrefab; set => attackPrefab = value; }
        protected Attack attackPrefab;

        public AttackInfo AttackInfo { get => attackInfo; set => attackInfo = value; }
        protected AttackInfo attackInfo;

        public Action<Attack> SpawnCallback = (inst) => {};
    }
}