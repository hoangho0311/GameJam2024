using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceWall : MonoBehaviour
{
    [SerializeField] string playerTag;
    [SerializeField] float bounceForce;
    AudioSource colsound;
    
    private void Start()
    {
        colsound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == playerTag)
        {
            CollisionSound();
            Rigidbody otherRB = collision.rigidbody;

            otherRB.velocity = new Vector3(0, 0, 0);
            //otherRB.AddExplosionForce(bounceForce, collision.contacts[0].point, 3, 5);
            otherRB.AddForce(Vector3.back * bounceForce, ForceMode.Impulse);
        }
    }

    void CollisionSound()
    {
       colsound.Play();
    }
    
}

