using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEnding : MonoBehaviour
{
    public GameObject loadingPanelControll;
    private void Start()
    {
        GameManager.instance.SetWinGame(true);
    }
    public void ClickCC()
    {
        loadingPanelControll.SetActive(true);
    }
}
