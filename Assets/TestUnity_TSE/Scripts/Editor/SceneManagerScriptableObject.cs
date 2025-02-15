using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneManagerScriptableObject", menuName = "Custom/SceneManagerSO")]
public class SceneManagerScriptableObject : ScriptableObject
{
    // Function to load a scene
    public void LoadScene(string ScenePath)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(ScenePath);
            Debug.Log("Load Scene: " + ScenePath);
        }
    }

    // Function to reload the current scene
    public void ReloadCurrentScene()
    {
        string CurrentScene = EditorSceneManager.GetActiveScene().path;
        if (!string.IsNullOrEmpty(CurrentScene))
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                EditorSceneManager.OpenScene(CurrentScene);
                Debug.Log("Scene reloaded successfully: " + CurrentScene);
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Attention", "No active scene found.", "OK");
            Debug.LogWarning("The scene to reload is invalid or not found: " + CurrentScene);
        }
    }

    // Function to add scene to Build Settings
    public void AddSceneToBuild(string ScenePath)
    {
        // Check if the scene has already been added to Build Settings
        EditorBuildSettingsScene[] CurrentScenes = EditorBuildSettings.scenes;
        foreach (var s in CurrentScenes)
        {
            if (s.path == ScenePath)
            {
                EditorUtility.DisplayDialog("Attention", "The scene is already in Build Settings.", "OK");
                Debug.LogWarning("The scene is already added to the Build Settings: " + ScenePath);
                return;
            }
        }

        // Add scene to Build Settings
        EditorBuildSettingsScene[] NewScenes = new EditorBuildSettingsScene[CurrentScenes.Length + 1];
        System.Array.Copy(CurrentScenes, NewScenes, CurrentScenes.Length);
        NewScenes[NewScenes.Length - 1] = new EditorBuildSettingsScene(ScenePath, true);
        EditorBuildSettings.scenes = NewScenes;
        EditorUtility.DisplayDialog("Success", "The scene has been added to Build Settings.", "OK");
        Debug.Log("The scene has been successfully added to Build Settings: " + ScenePath);
    }
}
