// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine.UI;

namespace Depra.Common.Unity.Runtime.Extensions.UI
{
    /// <summary>
    /// <see cref="Scrollbar"/> extensions.
    /// </summary>
    public static class ScrollbarExtensions
    {
        public static void ScrollToEnd(this Scrollbar scrollbar) => 
            scrollbar.value = 1;

        public static void ScrollToStart(this Scrollbar scrollbar) => 
            scrollbar.value = 0;
    }
}