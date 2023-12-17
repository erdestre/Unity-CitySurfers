using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject player;
    Rigidbody playerRb;
    Vector2 startTouchPosition, endTouchPosition;

    void Start()
    {
        player = GetComponent<GameObject>();
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(9).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
            if (endTouchPosition.x < startTouchPosition.x)
            {
                GoLeft();
            }
            else if (startTouchPosition.x < endTouchPosition.x)
            {
                GoRight();
            }
            if (endTouchPosition.y < startTouchPosition.y)
            {
                Roll();
            }
            else if (startTouchPosition.y < endTouchPosition.y) // && örnek: 50den fazla ise gibi bişey eklenecek
            {
                Jump();
            }
        }
    }

    void Roll()
    {

    }
    void Jump()
    {

    }
    void GoLeft()
    {

    }
    void GoRight()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            //dead animation

        }
    }
}
