using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] public enum SIDE { left, mid, right }

public class Player : MonoBehaviour
{
    public SIDE m_Side = SIDE.mid;
    public enum HitX { Left, Mid, Right, None };
    public enum HitY { Left, Mid, Right, None };
    public enum HitZ { Forward, Mid, Backward, None };
    public float xValue;
    public bool swipeLeft, swipeRight, swipeUp, swipeDown;
    public float speed;
    public float jumpHeight;
    public CameraBehaviour camera;
    float newXPos;
    private CharacterController m_char;
    private Animator m_Animator;
    private float x, y;
    public bool inJump;
    public float gravity;
    private bool inRoll;
    private float colHeight;
    private float colCenterY;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    public HitX hitX = HitX.None;
    public HitY hitY = HitY.None;
    public HitZ hitZ = HitZ.None;
    public float runSpeed = 3f;
    public float runSpeedIncreaseIndex = 0.5f;

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
        m_Animator.SetFloat("Speed", runSpeed / 6);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
            Debug.Log("startTouchPosition " + startTouchPosition);
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
            Debug.Log("endTouchPosition " + endTouchPosition);
            float differenceX;
            float differenceY;
            differenceX = startTouchPosition.x - endTouchPosition.x;
            differenceY = startTouchPosition.y - endTouchPosition.y;
            Debug.Log("differenceX " + differenceX);
            Debug.Log("differenceY " + differenceY);
            if (Mathf.Abs(differenceX) > 150f || Mathf.Abs(differenceY) > 150f)
            {
                if (Mathf.Abs(differenceX) > Mathf.Abs(differenceY))
                {
                    swipeRight = endTouchPosition.x > startTouchPosition.x;
                    if (!swipeRight)
                    {
                        swipeLeft = true;
                        Debug.Log("Left");
                    }
                    else
                    {
                        Debug.Log("Right");
                    }
                }
                else
                {
                    swipeUp = endTouchPosition.y > startTouchPosition.y;
                    if (!swipeUp)
                    {
                        swipeDown = true;
                        Debug.Log("Down");
                    }
                    else
                    {
                        Debug.Log("Up");

                    }
                }

            }
        }

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
        Vector3 moveVector = new Vector3(x - transform.position.x, y * Time.deltaTime, runSpeed * Time.deltaTime);
        x = Mathf.Lerp(x, newXPos, Time.deltaTime * speed);
        camera.ChangeCameraPos(newXPos, speed);
        m_char.Move(moveVector);
        Jump();
        Roll();
        ResetSwipe();
        RunSpeed();
    }

    private void RunSpeed()
    {
        runSpeed += runSpeedIncreaseIndex * Time.deltaTime;
    }

    private void Run()
    {

    }

    private void ResetSwipe() => swipeRight = swipeDown = swipeLeft = swipeUp = false;

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
            m_Animator.CrossFadeInFixedTime("Roll", 0.1f);
            inRoll = true;
            inJump = false;
        }

    }
    void Jump()
    {
        if (m_char.isGrounded)
        {
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
            inJump = false;
        }
    }
    public void OnCharacterColliderHit(Collider col)
    {
        hitX = GetHitX(col);
    }
    public HitX GetHitX(Collider col)
    {
        Bounds char_bounds = m_char.bounds;
        Bounds col_bounds = col.bounds;
        float min_x = MathF.Max(col_bounds.min.x, char_bounds.min.x);
        float max_x = MathF.Min(col_bounds.max.x, char_bounds.max.x);
        float average = (min_x + max_x / 2f - col_bounds.min.x);
        HitX hit;
        if (average > col_bounds.size.x - 0.33f)
            hit = HitX.Right;
        else if (average < 0.33f)
            hit = HitX.Left;
        else
            hit = HitX.Mid;
        return hit;
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            //dead animation

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            Destroy(other.gameObject);
        }
    }
}
