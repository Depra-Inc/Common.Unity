// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Depra.Common.Unity.Runtime.Extensions.Search
{
    public static class NearestPointSearchExtensions
    {
        /// <summary>
        /// Search nearest point.
        /// </summary>
        /// <param name="enumerable">Point as components</param>
        /// <param name="point">Position</param>
        /// <typeparam name="T">Point type</typeparam>
        /// <returns>Nearest/closest point</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Transform FindNearestPoint<T>(this IEnumerable<T> enumerable, Vector3 point) where T : Component
        {
            var distance = float.PositiveInfinity;
            Transform result = null;

            foreach (var component in enumerable)
            {
                var currentTransform = component.transform;
                var currentDistance = Vector3.Distance(currentTransform.position, point);
                if (currentDistance < distance == false)
                {
                    continue;
                }

                result = currentTransform;
                distance = currentDistance;
            }

            if (result == null)
            {
                throw new ArgumentNullException(nameof(enumerable), "Collection argument empty!");
            }

            return result;
        }

        [CanBeNull]
        public static T FindNearest<T>(this IEnumerable<T> array, List<T> skip, Vector3 point) where T : Component
        {
            var distance = float.PositiveInfinity;
            T result = null;

            foreach (var component in array)
            {
                if (skip.Contains(component))
                {
                    continue;
                }

                var currentTransform = component.transform;
                var currentDistance = Vector3.Distance(currentTransform.position, point);

                if (currentDistance < distance)
                {
                    result = component;
                    distance = currentDistance;
                }
            }

            return result;
        }

        [CanBeNull]
        public static T FindNearest<T>(this IEnumerable<T> array, Vector3 point) where T : Component
        {
            var distance = float.PositiveInfinity;
            T result = null;

            foreach (var component in array)
            {
                var currentTransform = component.transform;
                var currentDistance = Vector3.Distance(currentTransform.position, point);
                if (currentDistance < distance == false)
                {
                    continue;
                }

                result = component;
                distance = currentDistance;
            }

            return result;
        }

        [CanBeNull]
        public static T FindNearest<T>(this IEnumerable<T> array, Predicate<T> isIgnore, Vector3 point)
            where T : Component
        {
            var distance = float.PositiveInfinity;
            T result = null;

            foreach (var component in array)
            {
                if (isIgnore.Invoke(component))
                {
                    continue;
                }

                var currentTransform = component.transform;
                var currentDistance = Vector3.Distance(currentTransform.position, point);
                if (currentDistance < distance == false)
                {
                    continue;
                }

                result = component;
                distance = currentDistance;
            }

            return result;
        }

        [CanBeNull]
        public static T FindNearest<T>(this IEnumerable<T> array, Predicate<T> isIgnore, float maxDistance,
            Vector3 point) where T : Component
        {
            var distance = float.PositiveInfinity;
            T result = null;

            foreach (var component in array)
            {
                if (isIgnore.Invoke(component))
                {
                    continue;
                }

                var currentTransform = component.transform;
                var currentDistance = Vector3.Distance(currentTransform.position, point);
                if (currentDistance > maxDistance || currentDistance < distance == false)
                {
                    continue;
                }

                result = component;
                distance = currentDistance;
            }

            return result;
        }

        [CanBeNull]
        public static T FindNearest<T>(this IEnumerable<T> array, float maxDistance, Vector3 point) where T : Component
        {
            var distance = float.PositiveInfinity;
            T result = null;

            foreach (var component in array)
            {
                var currentTransform = component.transform;
                var currentDistance = Vector3.Distance(currentTransform.position, point);
                if (currentDistance > maxDistance || currentDistance < distance == false)
                {
                    continue;
                }

                result = component;
                distance = currentDistance;
            }

            return result;
        }
    }
}