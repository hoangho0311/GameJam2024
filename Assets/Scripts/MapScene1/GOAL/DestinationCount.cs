using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationCount : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (UIManager.Instance.limitTime >= 0 && !UIManager.Instance.isGameDone)
        {
            UIManager.Instance._currentRank++;

            if (UIManager.Instance.currentLevelRank == 3)
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    GameManager.instance.SetWinGame(true);
                }
                else
                {
                    GameManager.instance.SetWinGame(false);
                }
            }
            else
            {
                GameManager.instance.SetWinGame(true);
            }
        }
    }
}
