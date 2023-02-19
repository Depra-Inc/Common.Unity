// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Diagnostics;
using System.Linq;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Depra.Common.Unity.Runtime.Extensions.Objects
{
    public static class ScriptableObjectExtensions
    {
        private const string EDITOR_DEFINE = "UNITY_EDITOR";
        
        [Conditional(EDITOR_DEFINE)]
        public static void AddToPreloadedAssets(this ScriptableObject scriptableObject)
        {
#if UNITY_EDITOR
            var preloadedAssets = UnityEditor.PlayerSettings.GetPreloadedAssets().ToList();
            if (preloadedAssets.Any(preloadedAsset =>
                    preloadedAsset && preloadedAsset.GetInstanceID() == scriptableObject.GetInstanceID()))
            {
                // Already being preloaded.
                return;
            }

            preloadedAssets.Add(scriptableObject);

            UnityEditor.PlayerSettings.SetPreloadedAssets(preloadedAssets.ToArray());
#endif
        }

        [Conditional(EDITOR_DEFINE)]
        public static void RemoveEmptyPreloadedAssets()
        {
#if UNITY_EDITOR
            var preloadedAssets = UnityEditor.PlayerSettings.GetPreloadedAssets().ToList();
            var nonEmptyPreloadedAssets = preloadedAssets.Where(asset => asset).ToArray();

            UnityEditor.PlayerSettings.SetPreloadedAssets(nonEmptyPreloadedAssets);
#endif
        }

        [Conditional(EDITOR_DEFINE)]
        public static void AddSingleTypeInPreloadedAssets(this ScriptableObject scriptableObject)
        {
#if UNITY_EDITOR
            var passed = false;
            var preloadedAssets = UnityEditor.PlayerSettings.GetPreloadedAssets().ToList();
            foreach (var asset in preloadedAssets)
            {
                passed = asset.GetType() == scriptableObject.GetType();

                // Stop looping if we have an asset of this type in the player settings.
                if (passed)
                {
                    break;
                }
            }

            // Yikes, lets add this singleton to the player settings for them.
            if (passed)
            {
                return;
            }
            
            // Add the config asset to the build.
            preloadedAssets.Add(scriptableObject);
            UnityEditor.PlayerSettings.SetPreloadedAssets(preloadedAssets.ToArray());
            UnityEditor.AssetDatabase.SaveAssets();

            Debug.Log($"<b>Auto added {scriptableObject} asset to the player settings and saved to disk.</b>");
#endif
        }
    }
}