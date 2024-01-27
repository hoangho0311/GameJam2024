using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] float spawnValue;
    [SerializeField] GameObject player;
    [SerializeField] Transform respawnPoint;
    Animator anim;

    private RaycastHit hit;
    private int layerMask;
    public float distance = 5;
    AudioSource resp;

    void Awake()
    {
        player = GameObject.Find("Player");
        anim = player.GetComponentInChildren<Animator>();
        layerMask = 1 << 7;
        resp = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (!anim)
        {
            anim = player.GetComponentInChildren<Animator>();
        }
        /*
        if (player.transform.position.y < -spawnValue)
        {
            DownPlayer();
        }
        */
        if (Physics.Raycast(player.transform.position, -player.transform.up, out hit, distance, layerMask))
            DownPlayer();
    }

    void DownPlayer()
    {
        anim.SetBool("isFalling", true);
        resp.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetBool("isFalling", false);
            player.transform.position = respawnPoint.transform.position;
            //player.transform.GetChild(0).transform.position = new Vector3(0, 0.09f, 0);
            
        }
    }
    /*public void RespSound()
    {
        AudioSource resp = GetComponent<AudioSource>();
        resp.Play();
    }
    */
}
