using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AINavMesh : MonoBehaviour
{
    Vector3 destPos;
    NavMeshAgent agent;

    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        destPos = new Vector3(Random.Range(-10f, 7f), 61, Random.Range(570f, 578f));
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = destPos;
        FreezeRotation();
    }

    void FreezeRotation()
    {
        rigid.angularVelocity = Vector3.zero;
    }

}
