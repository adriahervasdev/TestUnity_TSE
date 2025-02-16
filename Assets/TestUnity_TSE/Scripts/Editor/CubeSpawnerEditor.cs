using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CubeSpawnerManager))]
public class CubeSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default UI
        DrawDefaultInspector();

        CubeSpawnerManager CubeSpawnerManager = (CubeSpawnerManager)target;

        // Add a slider to configure the number of cubes to generate between 1 and 10
        CubeSpawnerManager.CubesToSpawn = EditorGUILayout.IntSlider("Number of Cubes", CubeSpawnerManager.CubesToSpawn, 1, 10);

        // Add a button that triggers the cube generation
        if (GUILayout.Button("Generate Cubes"))
        {
            CubeSpawnerManager.SpawnCube();
        }

        // Add a button that clears the cubes from the scene
        if (GUILayout.Button("Clear Cubes"))
        {
            CubeSpawnerManager.ClearCubes();
        }
    }
}
