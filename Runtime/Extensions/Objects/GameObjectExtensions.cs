// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using UnityEngine;

namespace Depra.Common.Unity.Runtime.Extensions.Objects
{
    /// <summary>
    /// Helper methods for performing additional operations on <see cref="GameObject"/> instances.
    /// </summary>
    public static partial class GameObjectExtensions
    {
        /// <summary>
        /// Builds a string that represents a <see cref="GameObject"/>'s position in the scene hierarchy.
        /// </summary>
        /// <param name="gameObject">The <see cref="GameObject"/> to evaluate.</param>
        /// <returns>A string showing the parent/child chain from root-most <see cref="GameObject"/> to the given <see cref="GameObject"/>.</returns>
        public static string GetParentNameHierarchy(this GameObject gameObject)
        {
            var parentObj = gameObject.transform;
            var stack = new Stack<string>();

            while (parentObj != null)
            {
                stack.Push(parentObj.name);
                parentObj = parentObj.parent;
            }

            var nameHierarchy = "";
            while (stack.Count > 0)
            {
                nameHierarchy += stack.Pop() + "->";
            }

            return nameHierarchy;
        }
    }
}