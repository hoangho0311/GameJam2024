using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float speed = 0.2f;
    Material mat;

    void Start()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mat = mr.material;
    }

    void Update()
    {
        mat.mainTextureOffset += Vector2.down * speed * Time.deltaTime;
    }
}
