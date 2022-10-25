// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

namespace Depra.Common.Unity.Runtime.Math.Extensions
{
    /// <summary>
    /// <see cref="Vector3"/> extensions.
    /// </summary>
    public static class Vector3Extensions
    {
        /// <summary>
        /// Gets the square distance between two vector3 positions. this is much faster that Vector3.distance.
        /// </summary>
        /// <param name="first">First point</param>
        /// <param name="second">Second point</param>
        /// <returns>Squared distance</returns>
        public static float SqrDistance(this Vector3 first, Vector3 second) =>
            (first.x - second.x) * (first.x - second.x) +
            (first.y - second.y) * (first.y - second.y) +
            (first.z - second.z) * (first.z - second.z);

        public static Vector3 MidPoint(this Vector3 first, Vector3 second) => new Vector3(
            (first.x + second.x) * 0.5f,
            (first.y + second.y) * 0.5f,
            (first.z + second.z) * 0.5f);

        /// <summary>
        /// Get the square distance from a point to a line segment.
        /// </summary>
        /// <param name="point">Point to get distance to</param>
        /// <param name="lineP1">Line segment start point</param>
        /// <param name="lineP2">Line segment end point</param>
        /// <param name="closestPoint">Set to either 1, 2, or 4, determining which end the point is closest to (p1, p2, or the middle)</param>
        /// <returns></returns>
        public static float SqrLineDistance(this Vector3 point, Vector3 lineP1, Vector3 lineP2, out int closestPoint)
        {
            var v = lineP2 - lineP1;
            var w = point - lineP1;

            var c1 = Vector3.Dot(w, v);
            if (c1 <= 0) //closest point is p1
            {
                closestPoint = 1;
                return point.SqrDistance(lineP1);
            }

            var c2 = Vector3.Dot(v, v);
            if (c2 <= c1) //closest point is p2
            {
                closestPoint = 2;
                return SqrDistance(point, lineP2);
            }

            var b = c1 / c2;

            var pb = lineP1 + b * v;
            {
                closestPoint = 4;
                return SqrDistance(point, pb);
            }
        }

        /// <summary>
        /// Absolute value of components.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector3 Abs(this Vector3 v) =>
            new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));

        /// <summary>
        /// Vector3.Project, onto a plane
        /// </summary>
        /// <param name="v"></param>
        /// <param name="planeNormal"></param>
        /// <returns></returns>
        public static Vector3 ProjectOntoPlane(this Vector3 v, Vector3 planeNormal) =>
            v - Vector3.Project(v, planeNormal);

        public static float DistanceX(this Vector3 curVec, Vector3 toVec) => Mathf.Abs(toVec.x - curVec.x);

        public static float DistanceY(this Vector3 curVec, Vector3 toVec) => Mathf.Abs(toVec.y - curVec.y);

        public static float DistanceZ(this Vector3 curVec, Vector3 toVec) => Mathf.Abs(toVec.z - curVec.z);

        public static bool IsNaN(this Vector3 vec) => float.IsNaN(vec.x * vec.y * vec.z);
        
        public static Vector3 Center(this Vector3[] points)
        {
            var ret = Vector3.zero;
            foreach (var p in points)
            {
                ret += p;
            }

            ret /= points.Length;

            return ret;
        }
        
        public static float GetAngleFromVectorFloat(this Vector3 direction)
        {
            direction = direction.normalized;
            var n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (n < 0)
            {
                n += 360;
            }

            return n;
        }
    }
}