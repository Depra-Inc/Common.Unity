// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using Depra.Common.Unity.Runtime.Math.Extensions;
using UnityEngine;

namespace Depra.Common.Unity.Runtime.Extensions.Components
{
    public static partial class TransformExtensions
    {
        /// <summary>
        /// Creates TRS-matrix from transform.
        /// </summary>
        /// <param name="self">Self transform</param>
        /// <returns>TRS-matrix</returns>
        public static Matrix4x4 GetTRSMatrix(this Transform self) =>
            Matrix4x4.TRS(self.position, self.rotation, self.localScale);

        /// <summary>
        /// Applies the TRS-matrix to self transform.
        /// </summary>
        /// <param name="self">Self transform</param>
        /// <param name="matrix">Matrix to apply</param>
        /// <exception cref="ArgumentException">Not valid matrix</exception>
        public static void SetTRSMatrix(this Transform self, Matrix4x4 matrix)
        {
            if (matrix.ValidTRS() == false)
            {
                throw new ArgumentException("Not valid matrix.", nameof(matrix));
            }

            self.rotation = matrix.GetRotation();
            self.position = matrix.GetPosition();
            self.localScale = matrix.GetScale();
        }
    }
}