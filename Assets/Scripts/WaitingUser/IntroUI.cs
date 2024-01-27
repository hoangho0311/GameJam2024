using UnityEngine;

public class IntroUI : MonoBehaviour
{
    public GameObject missionUI;
    public GameObject missionPos;
    Vector3 dir;
    public float speed = 3f;
    
    void Update()
    {
        dir = missionPos.transform.position - missionUI.transform.position;
        missionUI.transform.position += dir * speed * Time.deltaTime;
    }
}
