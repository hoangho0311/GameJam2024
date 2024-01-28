using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LHS_Particle : MonoBehaviour
{
    public ParticleSystem winParticle;
    public ParticleSystem win;
    public GameObject winUI;

    public static LHS_Particle Instance;
    private void Awake()
    {
        Instance = this;
    }
    

    public void Success()
    {
        winUI.SetActive(true);
        winParticle.Play();
        win.Play();

        //winSound.Play();
    }
}
