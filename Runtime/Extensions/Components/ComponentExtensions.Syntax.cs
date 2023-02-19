// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

namespace Depra.Common.Unity.Runtime.Extensions.Components
{
    public static partial class ComponentExtensions
    {
        public static Vector3 Position(this Component component) => 
            component.transform.position;

        public static Vector3 LocalPosition(this Component component) => 
            component.transform.localPosition;

        public static Quaternion Rotation(this Component component) => 
            component.transform.rotation;

        public static Quaternion LocalRotation(this Component component) => 
            component.transform.localRotation;

        public static Vector3 Scale(this Component component) => 
            component.transform.localScale;

        public static Vector3 LossyScale(this Component component) => 
            component.transform.lossyScale;
    }
}