// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

namespace Depra.Common.Unity.Runtime.Extensions.UI
{
    /// <summary>
    /// <see cref="RectTransform"/> extensions.
    /// </summary>
    public static partial class RectTransformExtensions
    {
        public static void SetPivotX(this RectTransform self, float value) =>
            self.pivot = new Vector2(value, self.pivot.y);

        public static void SetPivotY(this RectTransform rt, float value) => 
            rt.pivot = new Vector2(rt.pivot.x, value);
    }
}