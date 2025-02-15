using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneManagerEditorWindow : EditorWindow
{
    private SceneManagerScriptableObject SceneManagerSO;
    private SceneAsset DropSceneAsset;

    // Add custom window to Unity editor
    [MenuItem("Window/Scene Manager")]
    public static void ShowWindow()
    {
        GetWindow<SceneManagerEditorWindow>("Scene Manager Editor Window");
    }

    // Draw custom UI for the SceneManager
    private void OnGUI()
    {
        // Assign the SceneManagerSO from the Inspector.
        SceneManagerSO = (SceneManagerScriptableObject)EditorGUILayout.ObjectField("Scene Manager SO", SceneManagerSO, typeof(SceneManagerScriptableObject), false);

        if (SceneManagerSO == null)
        {
            EditorGUILayout.HelpBox("Assign a SceneManagerSO asset.", MessageType.Warning);
            return;
        }

        // List the scenes currently in Build Settings
        GUILayout.Label("Scenes currently in Build Settings", EditorStyles.boldLabel);
        foreach (EditorBuildSettingsScene Scene in EditorBuildSettings.scenes)
        {
            if (!Scene.enabled) continue;

            GUILayout.BeginHorizontal();
            GUILayout.Label(Scene.path);
            if (GUILayout.Button("Cargar"))
            {
                SceneManagerSO.LoadScene(Scene.path);
            }
            GUILayout.EndHorizontal();
        }

        // Add button to reload the current scene
        GUILayout.Space(25);
        if (GUILayout.Button("Reload current scene"))
        {
            SceneManagerSO.ReloadCurrentScene();
        }

        // Add field to add scene to Build Settings
        GUILayout.Space(25);
        GUILayout.Label("Add scene to Build Settings", EditorStyles.boldLabel);
        DropSceneAsset = (SceneAsset)EditorGUILayout.ObjectField("Arrastra una escena", DropSceneAsset, typeof(SceneAsset), false);
        if (DropSceneAsset != null && GUILayout.Button("Add scene to Build Settings"))
        {
            string ScenePath = AssetDatabase.GetAssetPath(DropSceneAsset);
            SceneManagerSO.AddSceneToBuild(ScenePath);
            DropSceneAsset = null;
        }
    }
}
