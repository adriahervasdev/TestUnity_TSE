using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntanceChangeMaterial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Renderer Renderer = GetComponent<Renderer>();
        if (Renderer != null)
        {
            Renderer.material = new Material(Renderer.material);
            Renderer.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
