using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectDeleter : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
