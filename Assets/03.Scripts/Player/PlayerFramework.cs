using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace PlayerStrategy
{
    public interface IPlayerMove{};


    namespace PlayerWeapon
    {
        public abstract class PlayerWeapon: MonoBehaviour
        {
            protected void Start() 
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

            protected ILeftDown leftDown;
            protected ILeftHold leftHold;
            protected ILeftUp   leftUp;

            protected IRightDown rightDown;
            protected IRightHold rightHold;
            protected IRightUp   rightUp;

            public void OnLeftDown(){ leftDown.Trigger(); }
            public void OnLeftHold(){ leftHold.Trigger(); }
            public void OnLeftUp  (){ leftUp.Trigger(); }

            public void OnRightDown  (){ rightDown.Trigger(); }
            public void OnRightHold  (){ rightHold.Trigger(); }
            public void OnRightUp    (){ rightUp.Trigger(); }

        };

        public interface ILeftDown { public void Trigger(); }
        public interface ILeftHold { public void Trigger(); }
        public interface ILeftUp   { public void Trigger(); }

        public interface IRightDown { public void Trigger(); }
        public interface IRightHold { public void Trigger(); }
        public interface IRightUp   { public void Trigger(); }

        public class NoLeftDown : ILeftDown { public void Trigger(){}}
        public class NoLeftHold : ILeftHold { public void Trigger(){}}
        public class NoLeftUp   : ILeftUp   { public void Trigger(){}}
        public class NoRightDown : IRightDown { public void Trigger(){}}
        public class NoRightHold : IRightHold { public void Trigger(){}}
        public class NoRightUp   : IRightUp   { public void Trigger(){}}

    }
}
