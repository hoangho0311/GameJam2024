using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition instance;
    public GameObject LoadingScreen, startTransition, endTransition;
    public Slider loadingBarFill;
    private float target;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(StartTransition());
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "WaitingUser")
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Intro");
            }
        }

        if (SceneManager.GetActiveScene().name == "Intro")
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("InGame");
            }
        }

        loadingBarFill.value = Mathf.MoveTowards(loadingBarFill.value, target, 3 * Time.deltaTime);
    }

    public void LoginSceneChange()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void LobbySceneChange()
    {
        SceneManager.LoadScene("WaitingUser");
    }

    public void WaitingPalyersSceneChange()
    {
        SceneManager.LoadScene("Intro");
    }

    public void IntroSceneChange()
    {
        SceneManager.LoadScene("InGame");
    }

    public void InGameSceneChange()
    {
        SceneManager.LoadScene("Ending");
    }

    IEnumerator StartTransition()
    {
        startTransition.SetActive(true);
        yield return new WaitForSeconds(1);
        startTransition.SetActive(false);
    }

    public async void LoadingScene(int sceneID)
    {
        target = 0;
        var scene = SceneManager.LoadSceneAsync(sceneID);
        scene.allowSceneActivation = false;

        LoadingScreen.SetActive(true);

        do
        {
            await Task.Delay(1000);
            target = scene.progress;
        } while (scene.progress < 0.9f);

        await Task.Delay(1000);
        scene.allowSceneActivation = true;
        LoadingScreen.SetActive(false);
    }
    
    
}
