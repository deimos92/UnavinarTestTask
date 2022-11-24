﻿using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts.PlayerInput
{
    public class Utils
    {
        public static Vector3 ScreenToWorld(Camera camera, Vector3 position)
        {
            position.z = camera.nearClipPlane;
            return camera.ScreenToWorldPoint(position);
        }
    }
}
