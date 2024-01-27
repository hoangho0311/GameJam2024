using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
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
    int _currentRank = 0;
    public Text curRankUI;

    //public AudioSource mysfx;
    //public AudioClip winfx;
    //public AudioClip losefx;
   
    //public AudioClip losefx;


    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public int CurrentRank
    {
        get
        {
            return _currentRank;
        }
        set
        {
            _currentRank = value;
            curRankUI.text = _currentRank + " / 15";
        }
    }


    void Start()
    {
        GameObject player = GameObject.Find("Player");
        roundOver.SetActive(false);
    }

    float waitTime = 2f;
    float currentTime = 0;
    void Update()
    {
        Timer();
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
                    if (player.transform.position.z > 560)
                    {
                        if (currentTime > 3f)
                        {
                            roundOver.SetActive(false);
                            success.SetActive(true);

                            //winParticle.Play();
                            //win.Play();
                            //mysfx.PlayOneShot(winfx);
                            // winSound.Play();
                            //curretTime = 2;
                            LHS_Particle.Instance.Success();

                            LHS_Particle.Instance.transform.position =
                                player.transform.position + new Vector3(0, 4f, 0);
                        }
                    }
                    else
                    {
                        if (currentTime > 3f)
                        {
                            roundOver.SetActive(false);
                            failure.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}