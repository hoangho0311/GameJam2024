using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float speed = 0.2f;
    Material mat;


    // Start is called before the first frame update
    void Start()
    {
        // ���͸����� ã�� �ʹ�
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mat = mr.material;

  
    }

    // Update is called once per frame
    void Update()
    {
        // ����� ��ũ�� �ϰ� �ʹ�
        // P =  P0 + vt
        mat.mainTextureOffset += Vector2.down * speed * Time.deltaTime;

    
    }
}
