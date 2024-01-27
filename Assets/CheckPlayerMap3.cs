using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerMap3 : MonoBehaviour
{
    [SerializeField] GameObject player;
    Animator anim;

    private RaycastHit hit;
    private int layerMask;
    public float distance = 5;

    void Awake()
    {
        player = GameObject.Find("Player");
        anim = player.GetComponentInChildren<Animator>();
        layerMask = 1 << 7;
    }

    private void Update()
    {
        if (UIManager.Instance.limitTime <= 5)
        {
            GameManager.instance.SetWinGame(true);
        }
    }

    private void FixedUpdate()
    {
        if (!anim)
        {
            anim = player.GetComponentInChildren<Animator>();
        }
        if (Physics.Raycast(player.transform.position, -player.transform.up, out hit, distance, layerMask))
        {
            DownPlayer();
        }
    }

    void DownPlayer()
    {
        anim.SetBool("isFalling", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("isFalling", false);
            UIManager.Instance.limitTime = 0;
            GameManager.instance.SetGameOver(true);
        }
    }
}
