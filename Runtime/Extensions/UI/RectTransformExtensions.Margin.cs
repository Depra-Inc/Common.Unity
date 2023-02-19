// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

namespace Depra.Common.Unity.Runtime.Extensions.UI
{
    public static partial class RectTransformExtensions
    {
        public static void SetMarginLeft(this RectTransform self, float left) =>
            self.offsetMin = new Vector2(left, self.offsetMin.y);

        public static void SetMarginRight(this RectTransform self, float right) =>
            self.offsetMax = new Vector2(-right, self.offsetMax.y);

        public static void SetMarginTop(this RectTransform self, float top) =>
            self.offsetMax = new Vector2(self.offsetMax.x, -top);

        public static void SetMarginBottom(this RectTransform self, float bottom) =>
            self.offsetMin = new Vector2(self.offsetMin.x, bottom);
    }
}