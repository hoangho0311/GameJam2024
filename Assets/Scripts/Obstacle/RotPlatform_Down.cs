using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotPlatform_Down : MonoBehaviour
{
    public float rotatingSpeed = 130;
    
    void Update()
    {
        transform.Rotate(Vector3.down, rotatingSpeed * Time.deltaTime);
    }
}
