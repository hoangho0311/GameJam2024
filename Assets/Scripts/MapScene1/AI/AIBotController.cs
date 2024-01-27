using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIBotController : MonoBehaviour
{
    [SerializeField] private LayerMask obstacleLayer;
    private bool isObstacleDetected = false;
    public GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward * 10f, out hit, 10f, obstacleLayer))
        {
            RotateFollowingDirection();
        }
    }

    private void RotateFollowingDirection()
    {
        Quaternion initialRotation = transform.rotation;

        if (Player)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Player.transform.position);
            transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, Random.Range(8, 15));
        }
        Vector3 direction = Player.transform.position - transform.position;
        direction.Normalize();
        transform.position += direction * 10 * Time.deltaTime;
    }
}
