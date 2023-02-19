// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

namespace Depra.Common.Unity.Runtime.Extensions.Objects
{
    public static partial class GameObjectExtensions
    {
        /// <summary>
        /// Is the object's layer in the specified <see cref="LayerMask"/>.
        /// </summary>
        /// <param name="gameObject">The <see cref="GameObject"/> to evaluate.</param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public static bool IsInLayerMask(this GameObject gameObject, LayerMask mask) =>
            (mask.value & (1 << gameObject.layer)) > 0;

        /// <summary>
        /// Move root and all children to the specified layer.
        /// </summary>
        /// <param name="root">The <see cref="GameObject"/> to evaluate.</param>
        /// <param name="layer">Target layer.</param>
        public static void MoveToLayerRecursive(this GameObject root, int layer)
        {
            root.layer = layer;
            foreach (Transform child in root.transform)
            {
                MoveToLayerRecursive(child.gameObject, layer);
            }
        }

        /// <summary>
        /// Move root and all children to the specified layer.
        /// </summary>
        /// <param name="root">The <see cref="GameObject"/> to evaluate.</param>
        /// <param name="layer">Target layer.</param>
        public static void MoveToLayer(this GameObject root, int layer)
        {
            root.gameObject.layer = layer;
            var children = root.GetComponentsInChildren<Transform>(includeInactive: true);
            
            foreach (var child in children)
            {
                child.gameObject.layer = layer;
            }
        }
    }
}