// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

namespace Depra.Common.Unity.Runtime.Extensions.Objects
{
    public static partial class GameObjectExtensions
    {
        public static bool HasComponent<T>(this GameObject obj) where T : Component =>
            obj.TryGetComponent(out T _);

        public static T GetOrAddComponent<T>(this GameObject obj) where T : Component =>
            obj.GetComponent<T>() ?? obj.AddComponent<T>();

        public static T GetInChildrenOrAddComponent<T>(this GameObject obj) where T : Component =>
            obj.GetComponentInChildren<T>() ?? obj.AddComponent<T>();
    }
}