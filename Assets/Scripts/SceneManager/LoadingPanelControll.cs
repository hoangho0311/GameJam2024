using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        
        if(SceneManager.GetActiveScene().name == "Lobby")
        {
            sceneTransition.LoadingScene(1, 1);
        }
        if (gameManager.GetWinGame())
        {
            if(currentLevel == 1)
            {
                sceneTransition.LoadingScene(2, 2);
            }
            else if(currentLevel == 2)
            {
                sceneTransition.LoadingScene(3, 3);
            }
            else if(currentLevel == 3)
            {
                sceneTransition.LoadingScene(4, 4);
            }
            else if (currentLevel == 4 && SceneManager.GetActiveScene().name == "Ending")
            {
                sceneTransition.LoadingScene(0, 1);
            }
        }
        else if(gameManager.GetGameOver())
        {
            sceneTransition.LoadingScene(0, 1);
        }
    }
}

