// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Depra.Common.Unity.Runtime.Extensions
{
    /// <summary>
    /// <see cref="Component"/> extensions.
    /// </summary>
    public static class ComponentExtensions
    {
        #region Syntax

        public static Vector3 Position(this Component component) => component.transform.position;

        public static Vector3 LocalPosition(this Component component) => component.transform.localPosition;

        public static Quaternion Rotation(this Component component) => component.transform.rotation;

        public static Quaternion LocalRotation(this Component component) => component.transform.localRotation;

        public static Vector3 Scale(this Component component) => component.transform.localScale;

        public static Vector3 LossyScale(this Component component) => component.transform.lossyScale;

        #endregion

        public static T GetSingleActive<T>(this IEnumerable<T> collection) where T : Component =>
            collection.FirstOrDefault(element => element.gameObject.activeInHierarchy);

        public static IEnumerable<GameObject> GetGameObjects(this IEnumerable<Component> components) =>
            components.Select(c => c.gameObject);

        public static T GetCopyOf<T>(this Component component, T other) where T : Component
        {
            var type = component.GetType();
            if (type != other.GetType())
            {
                return null;
            }

            const BindingFlags flags = BindingFlags.Public |
                                       BindingFlags.NonPublic |
                                       BindingFlags.Instance |
                                       BindingFlags.Default |
                                       BindingFlags.DeclaredOnly;

            var propertyInfos = type.GetProperties(flags);
            foreach (var propertyInfo in propertyInfos)
            {
                if (propertyInfo.CanWrite == false)
                {
                    continue;
                }

                try
                {
                    propertyInfo.SetValue(component, propertyInfo.GetValue(other, null), null);
                }
                catch
                {
                    // Ignored.
                }
            }

            var fieldInfos = type.GetFields(flags);
            foreach (var fieldInfo in fieldInfos)
            {
                fieldInfo.SetValue(component, fieldInfo.GetValue(other));
            }

            return component as T;
        }
    }
}