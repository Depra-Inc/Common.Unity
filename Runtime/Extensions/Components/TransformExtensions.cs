// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Depra.Common.Unity.Runtime.Extensions.Components
{
    /// <summary>
    /// <see cref="Transform"/> extensions.
    /// </summary>
    public static partial class TransformExtensions
    {
        /// <summary>
        /// Returns children of self transform.
        /// </summary>
        /// <param name="self">Self transform</param>
        /// <param name="nesting">Get children's children or not</param>
        /// <returns>Transform's children enumerable</returns>
        public static IEnumerable<Transform> GetChildren(this Transform self, bool nesting = false)
        {
            var children = new Transform[self.childCount];
            for (var i = 0; i < children.Length; i++)
            {
                children[i] = self.GetChild(i);
            }

            if (nesting == false || self.childCount == 0)
            {
                return children;
            }

            return children.Concat(children.SelectMany(value => value.GetChildren()));
        }

        /// <summary>
        /// Returns children of self transform with specified nesting level.
        /// </summary>
        /// <param name="self">Self transform</param>
        /// <param name="nestingLevel">Specified nesting level</param>
        /// <returns>Transform's children enumerable</returns>
        public static IEnumerable<Transform> GetChildren(this Transform self, int nestingLevel)
        {
            var children = self.GetChildren(false);
            if (nestingLevel <= 1 || self.childCount == 0)
            {
                return children;
            }

            return children.Concat(children
                    .SelectMany(value => value
                        .GetChildren(nestingLevel - 1)))
                .ToArray();
        }

        /// <summary>
        /// Checks is other transform is child of self.
        /// </summary>
        /// <param name="self">Self transform.</param>
        /// <param name="other">Another transform.</param>
        /// <param name="nesting">Check the nested transforms or not.</param>
        /// <returns>True if other is child of self and false otherwise.</returns>
        public static bool IsParentOf(this Transform self, Transform other, bool nesting = false) =>
            nesting ? self.GetChildren(true).Contains(other) : other.IsChildOf(self);

        public static Vector3 DirectionTo(this Transform source, Transform target) =>
            source.DirectionTo(target.position);

        public static Vector3 DirectionTo(this Transform source, Vector3 target) =>
            (target - source.position).normalized;

        public static void SetZLocal(this Transform transform, float zValue)
        {
            var localPosition = transform.localPosition;
            localPosition.z = zValue;
            transform.localPosition = localPosition;
        }

        public static void SetYLocal(this Transform transform, float yValue)
        {
            var localPosition = transform.localPosition;
            localPosition.y = yValue;
            transform.localPosition = localPosition;
        }

        public static void SetXLocal(this Transform transform, float xValue)
        {
            var localPosition = transform.localPosition;
            localPosition.x = xValue;
            transform.localPosition = localPosition;
        }

        public static void SetXWorld(this Transform transform, float xValue)
        {
            var localPosition = transform.position;
            localPosition.x = xValue;
            transform.position = localPosition;
        }

        public static void SetYWorld(this Transform transform, float yValue)
        {
            var localPosition = transform.position;
            localPosition.y = yValue;
            transform.position = localPosition;
        }

        public static void SetXZLocal(this Transform transform, float x, float z)
        {
            var localPosition = transform.localPosition;
            localPosition.x = x;
            localPosition.z = z;
            transform.localPosition = localPosition;
        }

        public static void SetXZLocal(this Transform transform, Transform newLp)
        {
            var localPosition = transform.localPosition;
            localPosition.x = newLp.localPosition.x;
            localPosition.z = newLp.localPosition.z;
            transform.localPosition = localPosition;
        }

        public static void SetXZWorld(this Transform transform, Transform newLp)
        {
            var localPosition = transform.position;
            localPosition.x = newLp.position.x;
            localPosition.z = newLp.position.z;
            transform.position = localPosition;
        }
    }
}