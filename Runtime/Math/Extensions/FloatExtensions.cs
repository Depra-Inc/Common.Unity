// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

namespace Depra.Common.Unity.Runtime.Math.Extensions
{
    public static class FloatExtensions
    {
        /// <summary>
        /// Loops the value, so that it is never larger than length and never smaller than 0.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        public static float Repeat(this float value, float length) => Mathf.Repeat(value, length);
        
        public static float ToThePowerOf(this float @base, float exponent)
            => Mathf.Pow(@base, exponent);
        
        public static float AbsoluteValue(this float value)
            => Mathf.Abs(value);
        
        public static float Sign(this float value)
            => Mathf.Sign(value);
        
        public static int RoundToInt(this float value)
            => Mathf.RoundToInt(value);
    }
}