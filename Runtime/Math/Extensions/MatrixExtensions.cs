// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

namespace Depra.Common.Unity.Runtime.Math.Extensions
{
    /// <summary>
    /// <see cref="Matrix4x4"/> extensions.
    /// </summary>
    public static class MatrixExtensions
    {
        /// <summary>
        /// Gets position of TRS-matrix.
        /// </summary>
        /// <param name="matrix">TRS-matrix.</param>
        /// <returns>Position of matrix.</returns>
        public static Vector3 GetPosition(this Matrix4x4 matrix)
        {
            var position = new Vector3(matrix.m03, matrix.m13, matrix.m23);

            return position;
        }

        /// <summary>
        /// Gets rotation of TRS-matrix.
        /// </summary>
        /// <param name="matrix">TRS-matrix.</param>
        /// <returns>Rotation of matrix.</returns>
        public static Quaternion GetRotation(this Matrix4x4 matrix)
        {
            var forward = new Vector3(matrix.m02, matrix.m12, matrix.m22);
            var upwards = new Vector3(matrix.m01, matrix.m11, matrix.m21);

            return Quaternion.LookRotation(forward, upwards);
        }

        /// <summary>
        /// Gets scale of TRS-matrix.
        /// </summary>
        /// <param name="matrix">TRS-matrix.</param>
        /// <returns>Scale of matrix.</returns>
        public static Vector3 GetScale(this Matrix4x4 matrix)
        {
            var scale = new Vector3()
            {
                x = new Vector4(matrix.m00, matrix.m10, matrix.m20, matrix.m30).magnitude,
                y = new Vector4(matrix.m01, matrix.m11, matrix.m21, matrix.m31).magnitude,
                z = new Vector4(matrix.m02, matrix.m12, matrix.m22, matrix.m32).magnitude,
            };

            return scale;
        }

        /// <summary>
        /// Sets position to TRS-matrix.
        /// </summary>
        /// <param name="matrix">Self TRS-matrix.</param>
        /// <param name="position">Position to set.</param>
        /// <returns>Matrix with new position.</returns>
        public static Matrix4x4 SetPosition(this Matrix4x4 matrix, Vector3 position)
        {
            matrix.m03 = position.x;
            matrix.m13 = position.y;
            matrix.m23 = position.z;

            return matrix;
        }

        /// <summary>
        /// Sets rotation to TRS-matrix.
        /// </summary>
        /// <param name="matrix">Self TRS-matrix.</param>
        /// <param name="rotation">Rotation to set.</param>
        /// <returns>Matrix with new rotation.</returns>
        public static Matrix4x4 SetRotation(this Matrix4x4 matrix, Quaternion rotation)
        {
            var forward = rotation * Vector3.forward;
            matrix.m02 = forward.x;
            matrix.m12 = forward.y;
            matrix.m22 = forward.z;

            var upwards = rotation * Vector3.up;
            matrix.m01 = upwards.x;
            matrix.m11 = upwards.y;
            matrix.m21 = upwards.z;

            return matrix;
        }

        /// <summary>
        /// Sets scale to TRS-matrix.
        /// </summary>
        /// <param name="matrix">Self TRS-matrix.</param>
        /// <param name="scale">Scale to set.</param>
        /// <returns>Matrix with new scale.</returns>
        public static Matrix4x4 SetScale(this Matrix4x4 matrix, Vector3 scale)
        {
            matrix = Matrix4x4.TRS(matrix.GetPosition(), matrix.GetRotation(), scale);

            return matrix;
        }
    }
}