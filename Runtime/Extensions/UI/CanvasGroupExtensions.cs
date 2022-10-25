// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

namespace Depra.Common.Unity.Runtime.Extensions.UI
{
    /// <summary>
    /// <see cref="CanvasGroup"/> extensions.
    /// </summary>
    public static class CanvasGroupExtensions
    {
        public static void SetInteractableAndBlocksRaycasts(this CanvasGroup canvasGroup, bool value)
        {
            canvasGroup.interactable = value;
            canvasGroup.blocksRaycasts = value;
        }
    }
}