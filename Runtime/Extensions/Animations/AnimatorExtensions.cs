// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Linq;
using UnityEngine;

namespace Depra.Common.Unity.Runtime.Extensions.Animations
{
    /// <summary>
    /// <see cref="Animator"/> extensions.
    /// </summary>
    public static class AnimatorExtensions
    {
        public static bool GetIsMainLayerOrHasWeight(this Animator animator, int layerIndex) =>
            layerIndex == 0 || animator.GetLayerWeight(layerIndex) > 0;

        public static string GetCurrentAnimationName(this Animator animator, int layer = 0)
        {
            var clipsInfo = animator.GetCurrentAnimatorClipInfo(layer);
            var clipsIsNullOrEmpty = clipsInfo == null || clipsInfo.Length == 0;
            
            return clipsIsNullOrEmpty ? null : clipsInfo[0].clip.name;
        }

        public static string GetNextAnimationName(this Animator animator, int layer = 0)
        {
            var clipsInfo = animator.GetNextAnimatorClipInfo(layer);
            var clipsIsNullOrEmpty = clipsInfo == null || clipsInfo.Length == 0;
            
            return clipsIsNullOrEmpty ? null : clipsInfo[0].clip.name;
        }

        public static float GetCurrentAnimationLength(this Animator animator, int layer = 0) =>
            animator.GetCurrentAnimatorStateInfo(layer).length;

        public static float GetCurrentAnimationTime(this Animator animator, int layer = 0)
        {
            var stateInfo = animator.GetCurrentAnimatorStateInfo(layer);
            var clipsInfo = animator.GetCurrentAnimatorClipInfo(layer);
            var clipsIsNullOrEmpty = clipsInfo == null || clipsInfo.Length == 0;

            return clipsIsNullOrEmpty ? 0 : clipsInfo[0].clip.length * stateInfo.normalizedTime;
        }

        public static float GetRemainingAnimationTime(this Animator animator, int layer = 0) =>
            animator.GetCurrentAnimationLength(layer) - animator.GetCurrentAnimationTime(layer);

        public static bool HasParameter(this Animator animator, string paramName)
        {
            for (var i = 0; i < animator.parameters.Length; i++)
            {
                if (animator.parameters[i].name == paramName)
                {
                    return true;
                }
            }

            return false;
        }

        public static float GetAnimationClipLength(this RuntimeAnimatorController animator, string stateName)
        {
            return (from clip in animator.animationClips
                    where clip.name.Equals(stateName, StringComparison.InvariantCultureIgnoreCase)
                    select clip.length
                ).FirstOrDefault();
        }
    }
}