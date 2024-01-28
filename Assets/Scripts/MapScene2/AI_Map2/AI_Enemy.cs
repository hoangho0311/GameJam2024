using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Levels;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AIEnemy : MonoBehaviour
{
    Vector3 destPos;
    NavMeshAgent agent;
    private RaycastHit hit;
    public LayerMask DoorObstacles;
    private float offsetX;

    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        destPos = new Vector3(Random.Range(-6f, 10f), 9.6f, Random.Range(378, 383));
        offsetX = destPos.x;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = destPos;
        isMoveToward();
        FreezeRotation();
    }

    private void isMoveToward()
    {
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 3, DoorObstacles))
        {
            if (!hit.collider.gameObject.GetComponent<DoorDashWall>() && hit.collider.gameObject.GetComponentInChildren<DodgeDoor>())
            {
                hit.collider.gameObject.GetComponent<NavMeshObstacle>().carving = true;

            }
        }
    }

    void FreezeRotation()
    {
        rigid.angularVelocity = Vector3.zero;
    }

}
