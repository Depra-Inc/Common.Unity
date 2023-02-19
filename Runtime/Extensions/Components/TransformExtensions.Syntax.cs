// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Depra.Common.Unity.Runtime.Extensions.Components
{
    public static partial class TransformExtensions
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public static Vector3 backward(this Transform transform) => -transform.forward;

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public static Vector3 down(this Transform transform) => -transform.up;

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public static Vector3 left(this Transform transform) => -transform.right;
    }
}