// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;
using UnityEngine.Animations;

namespace Depra.Common.Unity.Runtime.Extensions.Animations
{
    /// <summary>
    /// <see cref="IConstraint"/> extensions.
    /// </summary>
    public static class ConstraintExtensions
    {
        public static void ConstrainToOnly(this IConstraint constraint, Transform target)
        {
            while (constraint.sourceCount > 1)
            {
                constraint.RemoveSource(constraint.sourceCount - 1);
            }

            if (constraint.sourceCount == 1)
            {
                constraint.SetSource(0, new ConstraintSource
                {
                    weight = 1,
                    sourceTransform = target
                });
            }
            else
            {
                constraint.AddSource(new ConstraintSource
                {
                    weight = 1,
                    sourceTransform = target
                });
            }

            constraint.constraintActive = true;
        }

        public static void Clear(this IConstraint constraint)
        {
            while (constraint.sourceCount > 0)
            {
                constraint.RemoveSource(constraint.sourceCount - 1);
            }
        }

        public static void ClearAndDisable(this IConstraint constraint)
        {
            constraint.constraintActive = false;
            constraint.Clear();
        }
    }
}