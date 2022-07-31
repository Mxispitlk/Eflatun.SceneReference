﻿using UnityEditor;
using UnityEngine;

namespace Eflatun.SceneReference.Editor.MapGeneratorTriggers
{
    [InitializeOnLoad]
    internal static class PlayModeListener
    {
        static PlayModeListener()
        {
            EditorApplication.playModeStateChanged += EditorApplication_OnPlayModeStateChanged;
        }

        private static void EditorApplication_OnPlayModeStateChanged(PlayModeStateChange state)
        {
            if (!SettingsManager.SceneGuidToPathMap.IsGenerationTriggerEnabled(SceneGuidToPathMapGenerationTriggers.BeforeEnterPlayMode))
            {
                Debug.LogWarning("Skipping scene GUID to path map generation before play mode. It is recommended to enable map generation before play mode, as an outdated map can result in broken scene references in runtime. You can enable it in Project Settings/Eflatun/Scene Reference.");
                
                return;
            }

            if (state == PlayModeStateChange.ExitingEditMode)
            {
                SceneGuidToPathMapGenerator.Run();
            }
        }
    }
}
