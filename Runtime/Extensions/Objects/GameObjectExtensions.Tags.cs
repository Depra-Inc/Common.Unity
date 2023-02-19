// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

namespace Depra.Common.Unity.Runtime.Extensions.Objects
{
    public static partial class GameObjectExtensions
    {
        /// <summary>
        /// Sets tags for the object and/or its children.
        /// </summary>
        /// <param name="gameObject">The <see cref="GameObject"/> to evaluate.</param>
        /// <param name="tag">Target tag.</param>
        /// <param name="needChildren"></param>
        public static void MoveToTag(this GameObject gameObject, string tag, bool needChildren) =>
            InternalMoveToTag(gameObject.transform, tag, needChildren);

        private static void InternalMoveToTag(this Transform root, string tag, bool needChildren)
        {
            root.gameObject.tag = tag;

            if (needChildren == false)
            {
                return;
            }

            foreach (Transform child in root)
            {
                InternalMoveToTag(child, tag, true);
            }
        }
    }
}