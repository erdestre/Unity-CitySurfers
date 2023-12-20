using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private Vector3 newPos;


    public void ChangeCameraPos(float newXPos, float speed)
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(newXPos / 2, transform.position.y, transform.position.z), Time.deltaTime * speed);
    }
}
