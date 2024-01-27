using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public SceneTransition sceneTransition;
    public GameManager gameManager;
    public float limitTime;
    public Text textTimer;
    int min;
    float sec;
    public GameObject roundOver;
    public GameObject success;
    public GameObject failure;
    public GameObject player;
    public GameObject destPos;
    public GameObject boxTriggerPoint;
    public int _currentRank;
    public Text curRankUI;
    public int currentLevelRank;

    private int isIncreaseLevel;

    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        isIncreaseLevel = 0;
        currentLevelRank = PlayerPrefs.GetInt("CurrentLevelRank");
        sceneTransition = SceneTransition.instance;
        gameManager = GameManager.instance;
        GameObject player = GameObject.Find("Player");
        roundOver.SetActive(false);

        if(currentLevelRank == 1)
        {
            curRankUI.text = _currentRank + " /20";
        }
        else if (currentLevelRank == 2)
        {
            curRankUI.text = _currentRank + " /15";
        }
        else if (currentLevelRank == 3)
        {
            curRankUI.text = _currentRank + " /10";
        }
    }

    float waitTime = 2f;
    float currentTime = 0;
    void Update()
    {
        if (!gameManager.GetGameOver())
            Timer();

        if (isIncreaseLevel == 1)
        {
            currentLevelRank = PlayerPrefs.GetInt("CurrentLevelRank");
            PlayerPrefs.SetInt("CurrentLevelRank", currentLevelRank+=1);
        }

        if (currentLevelRank == 1)
        {
            if(_currentRank == 20)
            {
                gameManager.SetGameOver(true);
                GameOverUi();
            }
        }
        else if (currentLevelRank == 2)
        {
            if (_currentRank == 15)
            {
                gameManager.SetGameOver(true);
                GameOverUi();
            }
        }
        else if (currentLevelRank == 3)
        {
            if (_currentRank == 10)
            {
                gameManager.SetGameOver(true);
                GameOverUi();
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
            roundOver.SetActive(true);

            currentTime += Time.deltaTime;

            if (roundOver.activeSelf == true)
            {
                if (currentTime > waitTime)
                {
                    if (gameManager.GetWinGame())
                    {
                        if (currentTime > 3f)
                        {
                            isIncreaseLevel++;
                            roundOver.SetActive(false);
                            success.SetActive(true);

                            LHS_Particle.Instance.Success();

                            LHS_Particle.Instance.transform.position = player.transform.position + new Vector3(0, 4f, 0);
                        }
                    }
                    else
                    {
                        if (currentTime > 3f)
                        {
                            isIncreaseLevel++;
                            roundOver.SetActive(false);
                            failure.SetActive(true);
                        }
                    }
                }
            }
        }
    }

    private void GameOverUi()
    {
        currentLevelRank = PlayerPrefs.GetInt("CurrentLevelRank");
        PlayerPrefs.SetInt("CurrentLevelRank", currentLevelRank += 1);
        roundOver.SetActive(false);
        failure.SetActive(true);
    }
}