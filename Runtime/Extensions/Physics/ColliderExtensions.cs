// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

namespace Depra.Common.Unity.Runtime.Extensions.Physics
{
    /// <summary>
    /// <see cref="Collider"/> extensions.
    /// </summary>
    public static class ColliderExtensions
    {
        public static Vector3 GetRandomPoint(this Collider collider)
        {
            var bounds = collider.bounds;

            var point = new Vector3(
                UnityEngine.Random.Range(bounds.min.x, bounds.max.x),
                UnityEngine.Random.Range(bounds.min.y, bounds.max.y),
                UnityEngine.Random.Range(bounds.min.z, bounds.max.z)
            );

            if (point != collider.ClosestPoint(point))
            {
                point = GetRandomPoint(collider);
            }

            return point;
        }

        public static void GetReliableBounds(this Collider collider, out Bounds bounds)
        {
            var initialState = collider.enabled;
            collider.enabled = true;
            bounds = collider.bounds;
            collider.enabled = initialState;
        }
    }
}