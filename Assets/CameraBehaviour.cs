using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private float x;

    public void ChangeCameraPos(float newXPos, float speed)
    {
        x = Mathf.Lerp(x, newXPos, Time.deltaTime * speed);
        //transform.position.Move((x - transform.position.x) * Vector3.right);
    }

}
