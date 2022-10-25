// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using UnityEngine.Events;

namespace Depra.Common.Unity.Runtime.Extensions.Events
{
    public static class DelegateExtensions
    {
        /// <summary>
        /// Converts Action to UnityAction.
        /// </summary>
        /// <param name="action">Action to convert.</param>
        /// <returns>Action converted to UnityAction.</returns>
        public static UnityAction ToUnityAction(this Action action) => new UnityAction(action);

        /// <summary>
        /// Converts UnityAction to Action.
        /// </summary>
        /// <param name="action">UnityAction to convert.</param>
        /// <returns>UnityAction converted to Action.</returns>
        public static Action ToAction(this UnityAction action) => new Action(action);
    }
}