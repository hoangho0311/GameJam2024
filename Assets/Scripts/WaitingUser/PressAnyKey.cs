using System.Collections;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{
    public GameObject pressText;
    float currentTime = 0;
    float waitingtime = 11f;
    
    void Awake()
    {
        pressText.SetActive(false);
        if (pressText.activeSelf == true)
        {
            StartCoroutine("ShowReady");
        }

    }
    
    IEnumerator ShowReady()
    {
        int count = 0;
        while (count < 100)
        {
            pressText.SetActive(true);
            yield return new WaitForSeconds(.5f);
            pressText.SetActive(false);
            yield return new WaitForSeconds(.5f);
            count++;
        }
    }
}
