using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
  
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward) * 10;

        if (Physics.Raycast(transform.position, fwd, 10))
        {
            Debug.Log("There is something in front of the object!");
        }


        Debug.DrawRay(transform.position, fwd, Color.green);
    }
}
