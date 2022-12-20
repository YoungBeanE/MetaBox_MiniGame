using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;


class ProjectBuild
{
    static string[] SCENES = FindEnabledEditorScenes();
    static string APP_NAME = "Mini_Defense";

    [MenuItem("Custom/Build/Build Windows")]
    static void PerformWindowsBuild()
    {
        string target_filename = "Build/" + APP_NAME + ".exe";
        GenericBuild(SCENES, target_filename, BuildTarget.StandaloneWindows64, BuildOptions.None);
    }

    private static string[] FindEnabledEditorScenes()
    {
        List<string> EditorScenes = new List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (!scene.enabled) continue;
            EditorScenes.Add(scene.path);
        }
        return EditorScenes.ToArray();
    }

    static void GenericBuild(string[] scenes, string target_filename, BuildTarget build_target, BuildOptions build_options)
    {
        //EditorUserBuildSettings.SwitchActiveBuildTarget(BuildPipeline.GetBuildTargetGroup(build_target), build_target);
        BuildPipeline.BuildPlayer(scenes, target_filename, build_target, build_options);
        
    }
}
