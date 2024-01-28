using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    public ParticleSystem bounce;
    private void OnCollisionEnter(Collision collision)
    {
        if (TryGetComponent<AI_Animation>(out var AIPlayer))
        {
            AIPlayer.AI_Anim.SetTrigger("Finish");
        }
        bounce.Play();
        bounce.transform.position = transform.position;
    }
}
