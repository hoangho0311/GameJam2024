using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterSelected : MonoBehaviour
{
    public int currentCharacterIndex = 0;
    public GameObject[] character;
    public Transform playerTransform;
    private string nameOject;
    // Start is called before the first frame update
    void Start()
    {
        currentCharacterIndex = PlayerPrefs.GetInt("currentCharacterIndex");

        SelectePlayer();
    }

    public void SelectePlayer()
    {
        GameObject _character = Instantiate(character[currentCharacterIndex], playerTransform);

        nameOject = playerTransform.GetChild(0).name;
        ToggleOject(nameOject);
    }

    public void ToggleOject(string nameOject)
    {
        GameObject characterDestroy = GameObject.Find(nameOject);
        Destroy(characterDestroy);
    }
}
