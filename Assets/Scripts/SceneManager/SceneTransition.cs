using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
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
                SceneManager.LoadScene("InGame2");
            }
        }
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
}
