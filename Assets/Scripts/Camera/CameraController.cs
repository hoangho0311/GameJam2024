using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float x;
    float y;
    public float distance = 10;
    public GameObject player;

    void LateUpdate()
    {
        CameraRotate();
    }
    
    void CameraRotate()
    {
        x += Input.GetAxis("Mouse X");
        y -= Input.GetAxis("Mouse Y");
        transform.rotation = Quaternion.Euler(y, x, 0);
        y = Mathf.Clamp(y, -10, 30);
        Vector3 reDistance = new Vector3(0f, -1.8f, distance);
        transform.position = player.transform.position - transform.rotation * reDistance;
    }
}
