using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    public int currentCharacterIndex;
    public GameObject[] imageCharacter;

    // Start is called before the first frame update
    void Start()
    {
        if (!(PlayerPrefs.HasKey("currentCharacterIndex")))
        {
            PlayerPrefs.SetInt("currentCharacterIndex", 0);
        }
        currentCharacterIndex = PlayerPrefs.GetInt("currentCharacterIndex");

        foreach (GameObject image in imageCharacter)
        {
            image.gameObject.SetActive(false);
        }

        imageCharacter[currentCharacterIndex].gameObject.SetActive(true);
    }
    private void Update()
    {
        PlayerPrefs.SetInt("currentCharacterIndex", currentCharacterIndex);
    }

    public void ChangeNext()
    {
        imageCharacter[currentCharacterIndex].gameObject.SetActive(false);
        currentCharacterIndex++;
        if (currentCharacterIndex == imageCharacter.Length)
        {
            currentCharacterIndex = 0;
        }
        imageCharacter[currentCharacterIndex].gameObject.SetActive(true);
    }

    public void ChangePrevious()
    {
        imageCharacter[currentCharacterIndex].gameObject.SetActive(false);
        currentCharacterIndex--;
        if (currentCharacterIndex == -1)
        {
            currentCharacterIndex = imageCharacter.Length - 1;
        }
        imageCharacter[currentCharacterIndex].gameObject.SetActive(true);
    }
}
