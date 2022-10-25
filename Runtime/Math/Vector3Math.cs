// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

namespace Depra.Common.Unity.Runtime.Math
{
    /// <summary>
    /// <see cref="Vector3"/> extensions.
    /// </summary>
    public struct Vector3Math
    {
        /// <summary>
        /// Gets the normal of the triangle formed by the 3 vectors
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <param name="vec3"></param>
        /// <returns></returns>
        public static Vector3 Vector3Normal(Vector3 vec1, Vector3 vec2, Vector3 vec3) =>
            Vector3.Cross((vec3 - vec1), (vec2 - vec1));

        /// <summary>
        /// Using the magic of 0x5f3759df
        /// </summary>
        /// <param name="vec1"></param>
        /// <returns></returns>
        // public static Vector3 FastNormalized(this Vector3 vec1)
        // {
        //     var componentMult = MathExtensions.FastInvSqrt(vec1.sqrMagnitude);
        //     return new Vector3(vec1.x * componentMult, vec1.y * componentMult, vec1.z * componentMult);
        // }

        /// <summary>
        /// Gets the center of two points.
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static Vector3 Center(Vector3 vec1, Vector3 vec2) =>
            new Vector3((vec1.x + vec2.x) / 2, (vec1.y + vec2.y) / 2, (vec1.z + vec2.z) / 2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction1"></param>
        /// <param name="direction2"></param>
        /// <param name="axis"></param>
        /// <returns></returns>
        public static float AngleAroundAxis(Vector3 direction1, Vector3 direction2, Vector3 axis)
        {
            direction1 -= Vector3.Project(direction1, axis);
            direction2 -= Vector3.Project(direction2, axis);

            var angle = Vector3.Angle(direction1, direction2);

            return angle * (Vector3.Dot(axis, Vector3.Cross(direction1, direction2)) < 0 ? -1 : 1);
        }

        /// <summary>
        /// Returns a random direction in a cone. a spread of 0 is straight, 0.5 is 180*
        /// </summary>
        /// <param name="spread"></param>
        /// <param name="forward">must be unit</param>
        /// <returns></returns>
        public static Vector3 RandomDirection(float spread, Vector3 forward) =>
            Vector3.Slerp(forward, UnityEngine.Random.onUnitSphere, spread);

        /// <summary>
        /// Find a point on the infinite line nearest to point.
        /// </summary>
        /// <param name="lineStart"></param>
        /// <param name="lineEnd"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 NearestPoint(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
        {
            var lineDirection = Vector3.Normalize(lineEnd - lineStart);
            var closestPoint = Vector3.Dot((point - lineStart), lineDirection) / 
                               Vector3.Dot(lineDirection, lineDirection);

            return lineStart + (closestPoint * lineDirection);
        }

        /// <summary>
        /// Find a point on the line segment nearest to point.
        /// </summary>
        /// <param name="lineStart"></param>
        /// <param name="lineEnd"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 NearestPointStrict(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
        {
            var fullDirection = lineEnd - lineStart;
            var lineDirection = Vector3.Normalize(fullDirection);
            var closestPoint = Vector3.Dot((point - lineStart), lineDirection) /
                               Vector3.Dot(lineDirection, lineDirection);

            return lineStart + (Mathf.Clamp(closestPoint, 0.0f, Vector3.Magnitude(fullDirection)) * lineDirection);
        }

        public static Vector3 Sinerp(Vector3 from, Vector3 to, float value)
        {
            value = Mathf.Sin(value * Mathf.PI * 0.5f);
            return Vector3.Lerp(from, to, value);
        }

        /// <summary>
        /// Calculates the intersection line segment between 2 lines (not segments).
        /// Returns false if no solution can be found.
        /// </summary>
        /// <returns></returns>
        public static bool CalculateLineLineIntersection(Vector3 line1Point1, Vector3 line1Point2,
            Vector3 line2Point1, Vector3 line2Point2, out Vector3 resultSegmentPoint1, out Vector3 resultSegmentPoint2)
        {
            // Algorithm is ported from the C algorithm of 
            // Paul Bourke at http://local.wasp.uwa.edu.au/~pbourke/geometry/lineline3d/
            resultSegmentPoint1 = new Vector3(0, 0, 0);
            resultSegmentPoint2 = new Vector3(0, 0, 0);

            var p1 = line1Point1;
            var p2 = line1Point2;
            var p3 = line2Point1;
            var p4 = line2Point2;
            var p13 = p1 - p3;
            var p43 = p4 - p3;

            if (p4.sqrMagnitude < float.Epsilon)
                return false;

            var p21 = p2 - p1;
            if (p21.sqrMagnitude < float.Epsilon)
                return false;

            var d1343 = p13.x * p43.x + p13.y * p43.y + p13.z * p43.z;
            var d4321 = p43.x * p21.x + p43.y * p21.y + p43.z * p21.z;
            var d1321 = p13.x * p21.x + p13.y * p21.y + p13.z * p21.z;
            var d4343 = p43.x * p43.x + p43.y * p43.y + p43.z * p43.z;
            var d2121 = p21.x * p21.x + p21.y * p21.y + p21.z * p21.z;

            var denom = d2121 * d4343 - d4321 * d4321;
            if (Mathf.Abs(denom) < float.Epsilon)
                return false;

            var numer = d1343 * d4321 - d1321 * d4343;

            var mua = numer / denom;
            var mub = (d1343 + d4321 * (mua)) / d4343;

            resultSegmentPoint1.x = p1.x + mua * p21.x;
            resultSegmentPoint1.y = p1.y + mua * p21.y;
            resultSegmentPoint1.z = p1.z + mua * p21.z;
            resultSegmentPoint2.x = p3.x + mub * p43.x;
            resultSegmentPoint2.y = p3.y + mub * p43.y;
            resultSegmentPoint2.z = p3.z + mub * p43.z;

            return true;
        }

        /// <summary>
        /// calculate velocity for throw object by angle with mass equal one
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static Vector3 CalculateVelocity(Vector3 from, Vector3 to, float angle)
        {
            var dir = to - from; // get Target Direction
            var height = dir.y; // get height difference
            dir.y = 0; // retain only the horizontal difference
            var dist = dir.magnitude; // get horizontal direction
            var a = angle * Mathf.Deg2Rad; // Convert angle to radians
            dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle.
            dist += height / Mathf.Tan(a); // Correction for small height differences

            // Calculate the velocity magnitude
            var velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
            var result = velocity * dir.normalized;
            return result; // Return a normalized vector.
        }

        public static Vector3 GetVectorFromAngle(float angle)
        {
            //var angleRadian = Mathf.Deg2Rad * angle;
            //return new Vector3(Mathf.Sin(angleRadian), 0, Mathf.Cos(angleRadian));

            var angleRadian = Mathf.Deg2Rad * (angle + 90f);
            return new Vector3(Mathf.Cos(angleRadian), 0, Mathf.Sin(angleRadian));
        }

        public static Vector3 GetVectorFromAngleInt(int angle)
        {
            var angleRadian = angle * (Mathf.PI / 180f);
            return new Vector3(Mathf.Cos(angleRadian), 0, Mathf.Sin(angleRadian));
        }
    }
}