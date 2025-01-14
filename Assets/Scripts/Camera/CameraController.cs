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
        // ¸¶¿ì½º ÁÂ¿ì ÀÌµ¿ ´©Àû
        x += Input.GetAxis("Mouse X");
        // ¸¶¿ì½º »óÇÏ ÀÌµ¿ ´©Àû
        y -= Input.GetAxis("Mouse Y");
        // ÀÌµ¿·®¿¡ µû¶ó Ä«¸Þ¶ó°¡ ¹Ù¶óº¸´Â ¹æÇâ Á¶Á¤
        transform.rotation = Quaternion.Euler(y, x, 0);
        // µ¹¾Æ°¥ ¼ö ÀÖ´Â °¢µµ Á¦ÇÑ
        y = Mathf.Clamp(y, -10, 30);
        // Ä«¸Þ¶ó¿Í ÇÃ·¹ÀÌ¾îÀÇ °Å¸®Á¶Á¤
        Vector3 reDistance = new Vector3(0f, -1.8f, distance);
        transform.position = player.transform.position - transform.rotation * reDistance;
    }
}
