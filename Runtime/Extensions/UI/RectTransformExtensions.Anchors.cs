// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

namespace Depra.Common.Unity.Runtime.Extensions.UI
{
    public static partial class RectTransformExtensions
    {
        public static void SetAnchoredPositionX(this RectTransform self, float xPos) =>
            self.anchoredPosition = new Vector2(xPos, self.anchoredPosition.y);

        public static void SetAnchoredPositionY(this RectTransform self, float yPos) =>
            self.anchoredPosition = new Vector2(self.anchoredPosition.x, yPos);


        public static void SetAnchorMinX(this RectTransform self, float value) =>
            self.anchorMin = new Vector2(value, self.anchorMin.y);

        public static void SetAnchorMinY(this RectTransform self, float value) =>
            self.anchorMin = new Vector2(self.anchorMin.x, value);

        public static void SetAnchorMaxX(this RectTransform self, float value) =>
            self.anchorMax = new Vector2(value, self.anchorMax.y);

        public static void SetAnchorMaxY(this RectTransform self, float value) =>
            self.anchorMax = new Vector2(self.anchorMax.x, value);
    }
}