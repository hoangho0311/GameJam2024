using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCenter : MonoBehaviour
{
    public float rotatingSpeed = 130;
    
    void Update()
    {
        transform.Rotate(Vector3.forward, rotatingSpeed * Time.deltaTime);
    }
}
