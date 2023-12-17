using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public enum TouchPhase
    {
        RightPhase,
        LeftPhase,
        MiddlePhase
    }
    Camera camera;

    void Start()
    {
        camera = GetComponentInChildren<Camera>();
    }


    void ChangeCameraState()
    {

    }

}
