using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationCount : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.instance.GetGameOver())
        {
            UIManager.Instance._currentRank++;
            GameManager.instance.SetWinGame(true);
        }
    }
}
