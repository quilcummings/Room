using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var meshFilter = GetComponent<MeshFilter>();
        //Add one color for each vertex, and set them all to white
        Color[] colors = new Color[meshFilter.mesh.vertices.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = Color.white;
        }        meshFilter.mesh.colors = colors;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
