using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Stage
{
    public abstract class Weapon: MonoBehaviour
    {
        public Character Owner;

        public ILeftDown leftDown;
        public ILeftHold leftHold;
        public ILeftUp   leftUp;

        public IRightDown rightDown;
        public IRightHold rightHold;
        public IRightUp   rightUp;

        protected void Awake() 
        {
            Initiate();
            leftDown ??= new NoLeftDown();
            leftHold ??= new NoLeftHold();
            leftUp   ??= new NoLeftUp();

            rightDown ??= new NoRightDown();
            rightHold ??= new NoRightHold();
            rightUp   ??= new NoRightUp();
        }
        protected abstract void Initiate();
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
