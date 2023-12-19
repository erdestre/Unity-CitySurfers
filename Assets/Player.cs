using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] public enum SIDE { left, mid, right }

public class Player : MonoBehaviour
{
    public SIDE m_Side = SIDE.mid;
    public float xValue;
    public bool swipeLeft, swipeRight, swipeUp, swipeDown;
    public float speed;
    public float jumpHeight;
    float newXPos;
    private CharacterController m_char;
    private Animator m_Animator;
    private float x, y;
    public bool inJump;
    public float gravity;
    private bool inRoll;
    private float colHeight;
    private float colCenterY;


    void Start()
    {
        m_char = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator>();
        colHeight = m_char.height;
        colCenterY = m_char.center.y;
    }

    void Update()
    {
        swipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        swipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        swipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        swipeDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
        if (swipeLeft)
        {
            if (m_Side == SIDE.mid)
            {
                newXPos = -xValue;
                m_Side = SIDE.left;
                m_Animator.Play("GoLeft");
            }
            else if (m_Side == SIDE.right)
            {
                newXPos = 0;
                m_Side = SIDE.mid;
                m_Animator.Play("GoLeft");
            }

        }
        else if (swipeRight)
        {
            if (m_Side == SIDE.mid)
            {
                newXPos = xValue;
                m_Side = SIDE.right;
                m_Animator.Play("GoRight");
            }
            else if (m_Side == SIDE.left)
            {
                newXPos = 0;
                m_Side = SIDE.mid;
                m_Animator.Play("GoRight");
            }

        }
        Vector3 moveVector = new Vector3(x - transform.position.x, y * Time.deltaTime, 0);
        x = Mathf.Lerp(x, newXPos, Time.deltaTime * speed);
        m_char.Move(moveVector);
        Jump();
        Roll();


    }
    internal float RollCounter;
    void Roll()
    {
        RollCounter -= Time.deltaTime;
        if (RollCounter <= 0f)
        {
            RollCounter = 0;
            m_char.center = new Vector3(0, colCenterY, 0);
            m_char.height = colHeight;
            inRoll = false;
        }
        if (swipeDown)
        {
            RollCounter = 0.2f;
            y -= 10;
            m_char.center = new Vector3(0, colCenterY / 2f, 0);
            m_char.height = colHeight / 2f;
            m_Animator.CrossFadeInFixedTime("roll", 0.1f);
            inRoll = true;
            inJump = false;
        }

    }
    void Jump()
    {
        if (m_char.isGrounded)
        {
            if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Fall"))
            {
                m_Animator.Play("Landing");
                inJump = false;
            }
            if (swipeUp)
            {
                y = jumpHeight;
                m_Animator.CrossFadeInFixedTime("Jump", 0.1f);
                inJump = true;
            }
        }
        else
        {
            y -= jumpHeight * gravity * Time.deltaTime;
            if (m_char.velocity.y < -0.1f)
                m_Animator.Play("Fall");
            inJump = false;
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            //dead animation

        }
    }
}
