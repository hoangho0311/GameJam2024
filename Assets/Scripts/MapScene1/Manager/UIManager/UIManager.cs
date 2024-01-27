using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private SceneTransition sceneTransition;
    private GameManager gameManager;
    public float limitTime;
    public Text textTimer;
    int min;
    float sec;
    public GameObject roundOver;
    public GameObject success;
    public GameObject failure;
    public GameObject player;
    public int _currentRank;
    public Text curRankUI;
    public int currentLevelRank;
    
    public static UIManager Instance;

    public bool isGameDone;
    public GameObject loadingPanel;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        isGameDone = false;
        _currentRank = 0;
        currentLevelRank = PlayerPrefs.GetInt("CurrentLevelRank");
        sceneTransition = SceneTransition.instance;
        gameManager = GameManager.instance;
        GameObject player = GameObject.Find("Player");
        roundOver.SetActive(false);

        if(currentLevelRank == 1)
        {
            curRankUI.text = _currentRank + " /15";
        }
        else if (currentLevelRank == 2)
        {
            curRankUI.text = _currentRank + " /10";
        }
        else if (currentLevelRank == 3)
        {
            curRankUI.text = _currentRank + " /1";
        }
    }

    float waitTime = 3f;
    float currentTime = 0;
    void Update()
    {
        if (!gameManager.GetGameOver() || !gameManager.GetWinGame())
            Timer();


        if (currentLevelRank == 1 && limitTime >= 0)
        {
            curRankUI.text = _currentRank + " /15";
            if (_currentRank == 15)
            {
                CheckStatusGame();
            }
        }
        else if (currentLevelRank == 2 && limitTime >= 0)
        {
            curRankUI.text = _currentRank + " /10";
            if (_currentRank == 10)
            {
                CheckStatusGame();
            }
        }
        else if (currentLevelRank == 3)
        {
            curRankUI.text = _currentRank + " /1";
            if (_currentRank == 1)
            {
                CheckStatusGame();
            }
        }
    }

    void Timer()
    {
        limitTime -= Time.deltaTime;

        if (limitTime >= 60f)
        {
            min = (int)limitTime / 60;
            sec = (int)limitTime % 60;
            textTimer.text = min + " : " + sec.ToString("00");
        }
        if (limitTime < 60f)
            textTimer.text = "<color=white>" + (int)limitTime + "</color>";
        if (limitTime < 30f)
            textTimer.text = "<color=red>" + (int)limitTime + "</color>";
        if (limitTime <= 0)
        {
            textTimer.text = "<color=red>" + "Time Over" + "</color>";

            CheckStatusGame();
        }
    }

    public void CheckStatusGame()
    {
        isGameDone = true;
        roundOver.SetActive(true);

        currentTime += Time.deltaTime;

        if (roundOver.activeSelf == true)
        {
            if (currentTime > waitTime)
            {
                roundOver.SetActive(false);
                if (gameManager.GetWinGame())
                {
                    success.SetActive(true);
                    if (currentTime > 5f)
                    {
                        LHS_Particle.Instance.Success();

                        LHS_Particle.Instance.transform.position = player.transform.position + new Vector3(0, 4f, 0);
                        loadingPanel.SetActive(true);
                    }
                }
                else
                {
                    gameManager.SetGameOver(true);
                    failure.SetActive(true);
                    if (currentTime > 5f)
                    {
                        loadingPanel.SetActive(true);
                    }
                }
            }
        }
    }
}