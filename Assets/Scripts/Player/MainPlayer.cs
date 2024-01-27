using System;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public float speed = 10;
    public float rotateSpeed = 5;
    public float jumpPower;

    private Camera currentCamera;
    public bool UseCameraRotation = true;

    public ParticleSystem dust;

    public GameObject bar;

    public string playerTag;
    public float bounceForce;
    public ParticleSystem bounce;


    public AudioSource mysfx;
    public AudioClip jumpfx;
    public AudioClip bouncefx;

    Animator anim;
    Rigidbody rigid;
    bool isJump;
    //bool isGround;
    bool jDown;
    bool isDie;
    float hAxis;
    float vAxis;
    Vector3 moveVec;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

        bar.SetActive(true);
        bar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 3.35f, 0));
    }

    private void Start()
    {
        currentCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
       GetInput();
    }

    private void FixedUpdate()
    {
        FreezeRotation();
        Move();
        Turn();
        Jump();
        Die();
        Expression();
    }

    void FreezeRotation()
    {
        rigid.angularVelocity = Vector3.zero;
    }

    void GetInput()
    {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        jDown = Input.GetButtonDown("Jump");
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        if (UseCameraRotation)
        {
            Quaternion v3Rotation = Quaternion.Euler(0f, currentCamera.transform.eulerAngles.y, 0f);
            moveVec = v3Rotation * moveVec;
        }

        transform.position += moveVec * speed * Time.deltaTime;

        anim.SetBool("isMove", moveVec != Vector3.zero);
    }

    void Turn()
    {
        if (hAxis == 0 && vAxis == 0)
            return;
        Quaternion newRotation = Quaternion.LookRotation(moveVec);
        rigid.rotation = Quaternion.Slerp(rigid.rotation, newRotation, rotateSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if (jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * jumpPower * Time.fixedDeltaTime, ForceMode.Impulse);
            isJump = true;

            //anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            mysfx.PlayOneShot(jumpfx);
            dust.Play();
        }
    }

    void Die()
    {
        if (isDie)
        {
            anim.SetTrigger("doDie");
            isDie = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            anim.SetBool("isJump", false);
            isJump = false;
        }

        else if (collision.gameObject.tag == "Platform")
        {
            anim.SetBool("isJump", false);
            
            isJump = false;
        }

        else if (collision.collider.tag == "Wall")
        {
            anim.SetTrigger("doDie");
            isDie = false;

            rigid.velocity = new Vector3(0, 0, 0);
            rigid.AddForce(Vector3.back * bounceForce, ForceMode.Impulse);

            mysfx.PlayOneShot(bouncefx);
            bounce.Play();

            bounce.transform.position = transform.position;
        }

    }

    void Expression()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetTrigger("doDance01");
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetTrigger("doDance02");
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetTrigger("doVictory");
        }
    }

}



  



