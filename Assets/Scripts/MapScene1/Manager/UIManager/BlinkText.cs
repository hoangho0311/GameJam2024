using System.Collections;
using UnityEngine;

public class BlinkText : MonoBehaviour
{
    public GameObject readText;
    void Awake()
    {
        readText.SetActive(false);
        StartCoroutine(ShowReady());
    }

    IEnumerator ShowReady()
    {
        int count = 0;
        while (count < 100)
        {
            readText.SetActive(true);
            yield return new WaitForSeconds(.5f);
            readText.SetActive(false);
            yield return new WaitForSeconds(.5f);
            count++;
        }
    }
}
