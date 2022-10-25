// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine.UI;

namespace Depra.Common.Unity.Runtime.Extensions.UI
{
    /// <summary>
    /// <see cref="ScrollRect"/> extensions.
    /// </summary>
    public static class ScrollRectExtensions
    {
        public static void ScrollToBottom(this ScrollRect scrollRect) => 
            scrollRect.verticalNormalizedPosition = 0;

        public static void ScrollToTop(this ScrollRect scrollRect) => 
            scrollRect.verticalNormalizedPosition = 1;
    }
}