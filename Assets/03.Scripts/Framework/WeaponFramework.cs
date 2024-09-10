using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Stage
{
    public struct AttackInfo
    {
        public CharacterObject Attacker;
        public Weapon Weapon;
    }

    public abstract class Weapon: MonoBehaviour
    {
        [Header("Weapon Properties")]
        public AttackInfo AttackInfo;
        //

        protected void Awake() 
        {
            AttackInfo = new AttackInfo();
            SetStrategies();

            OnLeftDown ??= new NoLeftDown();
            OnLeftHold ??= new NoLeftHold();
            OnLeftUp   ??= new NoLeftUp();

            OnRightDown ??= new NoRightDown();
            OnRightHold ??= new NoRightHold();
            OnRightUp   ??= new NoRightUp();
        }

        protected abstract void SetStrategies();
        public abstract void Initiate();

        public ILeftDown OnLeftDown;
        public ILeftHold OnLeftHold;
        public ILeftUp   OnLeftUp;

        public IRightDown OnRightDown;
        public IRightHold OnRightHold;
        public IRightUp   OnRightUp;

    }

    public interface ILeftDown{ public void Invoke(); }
    public interface ILeftHold{ public void Invoke(); }
    public interface ILeftUp  { public void Invoke(); }

    public interface IRightDown{ public void Invoke(); }
    public interface IRightHold{ public void Invoke(); }
    public interface IRightUp{ public void Invoke(); }

    public class NoLeftDown: ILeftDown { public void Invoke(){}}
    public class NoLeftHold: ILeftHold { public void Invoke(){}}
    public class NoLeftUp  : ILeftUp   { public void Invoke(){}}

    public class NoRightDown: IRightDown { public void Invoke(){}}
    public class NoRightHold: IRightHold { public void Invoke(){}}
    public class NoRightUp  : IRightUp   { public void Invoke(){}}
    
}
