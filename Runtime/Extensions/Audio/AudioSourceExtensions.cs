// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

namespace Depra.Common.Unity.Runtime.Extensions.Audio
{
    /// <summary>
    /// <see cref="AudioSource"/> extensions.
    /// </summary>
    public static class AudioSourceExtensions
    {
        public static void TogglePlay(this AudioSource audioSource)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
            else
            {
                audioSource.Play();
            }
        }

        public static void ToggleMute(this AudioSource audioSource) =>
            audioSource.mute = !audioSource.mute;
    }
}