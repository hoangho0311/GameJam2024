using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Animation : MonoBehaviour
{
    public Animator AI_Anim;

    private void Start()
    {
        AI_Anim = GetComponentInChildren<Animator>();
    }
}
