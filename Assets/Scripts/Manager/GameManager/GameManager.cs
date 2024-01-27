using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    #region Encapsulation
    private bool isGameOver;
    private bool isGameStarted;
    private bool isPauseGame;
    private bool isWinGame;

    public bool GetGameOver()
    {
        return this.isGameOver;
    }

    public bool GetGameStart()
    {
        return this.isGameStarted;
    }

    public bool GetWinGame()
    {
        return this.isWinGame;
    }
    public bool GetPauseGame()
    {
        return this.isPauseGame;
    }
    
    public void SetWinGame(bool status)
    {
        this.isWinGame = status;
    }

    public void SetGameOver(bool status)
    {
        this.isGameOver = status;
    }

    public void SetGameStart(bool status)
    {
        this.isGameStarted = status;
    }

    public void SetPauseGame(bool status)
    {
        this.isPauseGame = status;
    }

    #endregion

    private void Awake()
    {
        isGameOver = false;
        isWinGame = false;
        instance = this;
    }

    private void Start()
    {
        //PlayerPrefs.DeleteAll();

        if (!PlayerPrefs.HasKey("FirstPlay"))
        {
            Debug.Log("Lan dau");
            PlayerPrefs.SetInt("FirstPlay", 1);
            PlayerPrefs.SetInt("CurrentLevelRank", 1);
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("CurrentLevelRank", 1);
    }
}
