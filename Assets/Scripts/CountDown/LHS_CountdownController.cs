using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 3, 2 ,1 , GO!�� �� �� ������ �����ϰ� �ʹ�
// ������ ���� �ִ´�
// 1�� �������� 3, 2, 1�� ���´�
// �ٲ� ������ UI�� ���� ����� �Ѵ�
// �ð��� �� ������ GO! UI�� ����
// �ٽ� ������ ���ش�

public class LHS_CountdownController : MonoBehaviour
{
    public int countdownTime = 4;

    public Text countdownDisplay;
    public GameObject anim;

    public GameObject Num_A;   //1��
    public GameObject Num_B;   //2��
    public GameObject Num_C;   //3��
    public GameObject Num_GO;
    //public GameObject Bar;
    
    // �ؽ�Ʈ ȿ��
    Animator animator;

    // ���� ȿ��
    public AudioSource mysfx;
    public AudioClip startsfx;
    public AudioClip gosfx;

    private void Awake()
    {
        
        animator = anim.GetComponent<Animator>();
        StartCoroutine(CountdownToStart());

        Num_A.SetActive(false); //1��
        Num_B.SetActive(false); //2��
        Num_C.SetActive(false); //3��
        Num_GO.SetActive(false);

        Time.timeScale = 0;
    }

    //�ڷ�ƾ �Լ� ���
    IEnumerator CountdownToStart()
    {
        //Bar.SetActive(true);

        while (countdownTime > 0)
        {
            //Bar.SetActive(true);

            ChangeImage();

            countdownDisplay.text = countdownTime.ToString();

            // 1�� ���
            yield return new WaitForSecondsRealtime(1f);

            countdownTime--;
        }

        // ������ ������ ����
        countdownDisplay.text = "GO!";
        //Num_GO.SetActive(false);

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
            //Num_C.SetActive(false);
            Num_B.SetActive(true);
            //animator.SetBool("Num3", true);
            mysfx.PlayOneShot(startsfx);
        }

        if (i == 2)
        {
            //Num_B.SetActive(false);
            Num_A.SetActive(true);
            //animator.SetBool("Num3", true);
            mysfx.PlayOneShot(startsfx);
        }

        if (i == 1)
        {
            //Num_A.SetActive(false);
            Num_GO.SetActive(true);
            //animator.SetBool("Num3", true);
            mysfx.PlayOneShot(gosfx);
        }

    }
}

