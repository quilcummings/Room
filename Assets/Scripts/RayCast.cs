using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
  
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward) * 10;

        Debug.DrawRay(transform.position, fwd, Color.green);

        Ray ray = new Ray(transform.position, fwd);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);

        if (Physics.Raycast(ray, out hit))
        {
            var mesh = hit.collider.GetComponent<MeshFilter>().mesh;
            Vector3 hitPoint = hit.point;
            hitPoint = hit.transform.InverseTransformPoint(hitPoint);
            
            Vector3[] vertices = mesh.vertices;
            Color[] colors = mesh.colors;
            
            for (int i = 0; i < vertices.Length; i++)
            {
                var distance = Vector3.Distance(vertices[i], hitPoint);
                if (distance < 0.1f)
                {
                    colors[i] *= 0.7f + (0.3f * distance / 0.2f);
                }
            }
            
            mesh.colors = colors;
        }
    }
}
