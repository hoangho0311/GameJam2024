using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHS_bouncing : MonoBehaviour
{
    public Vector3 MovePos;
    public float _speed = 4f;
    
    void Start()
    {
        MovePos = new Vector3(1f, 1f).normalized;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Wall"))
            transform.position += MovePos * _speed * Time.deltaTime;
    }
}
