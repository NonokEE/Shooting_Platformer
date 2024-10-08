using System.Collections;
using System.Collections.Generic;

using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Stage
{
    public static class StageTools
    {
        public static Vector3 MousePosition2D()
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            return Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, -Camera.main.transform.position.z));
        }

        public static quaternion GetQuatBy2D(Vector2 vector2)
        {
            float rotZ = Mathf.Atan2(vector2.y, vector2.x) * Mathf.Rad2Deg;
            return Quaternion.Euler(0, 0, rotZ);
        }

        public static quaternion GetQuatBy2D(float x, float y)
        {
            float rotZ = Mathf.Atan2(x, y) * Mathf.Rad2Deg;
            return Quaternion.Euler(0, 0, rotZ);
        }
    }
}