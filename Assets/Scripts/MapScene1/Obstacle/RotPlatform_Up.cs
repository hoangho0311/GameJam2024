using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotPlatform_Up : MonoBehaviour
{
    public float rotatingSpeed = 130;
    
    void Update()
    {
        transform.Rotate(Vector3.up, rotatingSpeed * Time.deltaTime);
    }
}
