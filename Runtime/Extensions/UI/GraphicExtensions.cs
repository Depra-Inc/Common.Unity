// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;
using UnityEngine.UI;

namespace Depra.Common.Unity.Runtime.Extensions.UI
{
    /// <summary>
    /// <see cref="Graphic"/> extensions.
    /// </summary>
    public static class GraphicExtensions
    {
        public static void SetAlpha(this Graphic graphic, float alpha) =>
            graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, alpha);
    }
}