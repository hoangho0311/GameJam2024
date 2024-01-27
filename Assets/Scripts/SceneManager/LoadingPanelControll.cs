using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingPanelControll : MonoBehaviour
{
    private SceneTransition sceneTransition;
    private GameManager gameManager;
    private int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevelRank");
        gameManager = GameManager.instance;
        sceneTransition = SceneTransition.instance;
        if (gameManager.GetWinGame())
        {
            if(currentLevel == 1)
            {
                sceneTransition.LoadingScene(1, 2);
            }
            else if(currentLevel == 2)
            {
                sceneTransition.LoadingScene(2, 3);
            }
            else if(currentLevel == 3)
            {
                sceneTransition.LoadingScene(2, 4);
            }
            else if (currentLevel == 4)
            {
                //Ending Scene
                sceneTransition.LoadingScene(3, 1);
            }
        }
        else if(gameManager.GetGameOver())
        {
            sceneTransition.LoadingScene(0, 1);
        }
    }
}

