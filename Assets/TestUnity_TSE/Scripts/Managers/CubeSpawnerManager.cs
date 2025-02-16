using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeSpawnerManager : MonoBehaviour
{
    // Cube Prefab
    public GameObject CubePrefab;

    // Reference to the UI text to display the number of cubes
    public Text CubeCountText;
    
    // The range of units where cubes will spawn, i.e., from '-x' to 'x' and from '-z' to 'z' with the defined value.
    public float SquareUnitsRange = 10f;
    
    // Number of cubes to generate
    [HideInInspector] public int CubesToSpawn = 1;

    private void Start()
    {
        UpdateUI(); // Asegura que la UI se actualiza al iniciar la escena
    }

    // Generate cubes based on the defined parameters
    public void SpawnCube()
    {
        if (CubePrefab == null)
        {
            Debug.LogWarning("The cube prefab has not been assigned.");
            return;
        }

        for (int i = 0; i < CubesToSpawn; i++)
        {
            // Calculate random position
            Vector3 randomPosition = new Vector3(
                Random.Range(-SquareUnitsRange, SquareUnitsRange),
                Random.Range(0f, 0f),
                Random.Range(-SquareUnitsRange, SquareUnitsRange)
            );

            // Instantiate the prefab at the random position within the parent's hierarchy
            GameObject Cube = Instantiate(CubePrefab, randomPosition, Quaternion.identity);
            Cube.transform.SetParent(this.transform);
        }

        Debug.Log(CubesToSpawn + " cubes generated.");
        UpdateUI();
    }

    // Remove all generated cubes in the scene
    public void ClearCubes()
    {
        // Get the number of generated children
        int NumberOfCubes = transform.childCount; 
        int CubesRemoved = 0;

        // Iterate through the children and remove them from the scene
        for (int i = NumberOfCubes - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
            CubesRemoved++;
        }

        Debug.Log("All instantiated cubes have been deleted. Total cubes deleted: " + CubesRemoved);
        UpdateUI(); 
    }

    // Update the UI text with the current number of cubes
    private void UpdateUI()
    {
        if (CubeCountText != null)
        {
            CubeCountText.text = "Cubes in the scene: " + transform.childCount;
        }
        else
        {
            Debug.LogWarning("The Text component in the UI has not been assigned.");
        }
    }
}
