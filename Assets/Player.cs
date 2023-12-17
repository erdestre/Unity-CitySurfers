using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject player;
    Rigidbody playerRb;

    void Start()
    {
        player = GetComponent<GameObject>();
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
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
