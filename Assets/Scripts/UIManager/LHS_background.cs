using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHS_background : MonoBehaviour
{
   
    // �¿�� �̵������� x�ִ밪
    public float delta = 0.02f;
    // �̵��ӵ�
    public float speed = 20f;

    // ������ġ
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = pos;
        // �¿� �̵��� �ִ�ġ �� ���� ó��
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;

    }
}
