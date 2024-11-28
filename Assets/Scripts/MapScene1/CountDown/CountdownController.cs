using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public Animator animator;
    public int countdownTime = 4;
    public Text countdownDisplay;

    [Header("Number")]
    public GameObject Num_A;   
    public GameObject Num_B;   
    public GameObject Num_C;   
    public GameObject Num_GO;

    [Header("Audio Source")]
    public AudioSource mysfx;
    public AudioClip startsfx;
    public AudioClip gosfx;
    

    private void Awake()
    {
        
        Num_A.SetActive(false); 
        Num_B.SetActive(false); 
        Num_C.SetActive(false); 
        Num_GO.SetActive(false);
    }

    public void StartCountDown()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        Time.timeScale = 0;
        while (countdownTime > 0)
        {
            ChangeImage();
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSecondsRealtime(1f);

            countdownTime--;
        }

        countdownDisplay.text = "GO!";
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(1f);

        countdownDisplay.gameObject.SetActive(false);
    }

    void ChangeImage()
    {
        int i = countdownTime;

        if (i == 4)
        {
            Num_C.SetActive(true);
            animator.SetBool("Num3", true);
            mysfx.PlayOneShot(startsfx);

        }

        if (i == 3)
        {
            Num_B.SetActive(true);
            mysfx.PlayOneShot(startsfx);
        }
        
        if (i == 2)
        {
            Num_A.SetActive(true);
            mysfx.PlayOneShot(startsfx);
        }

        if (i == 1)
        {
            Num_GO.SetActive(true);
            mysfx.PlayOneShot(gosfx);
        }

    }
}

