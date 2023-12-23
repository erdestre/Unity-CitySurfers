using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Collectable : MonoBehaviour
{
    private void Update()
    {
        RotateObject();
        //ChangePostition();
    }

    private void RotateObject()
    {
        gameObject.transform.Rotate(0, 50f * Time.deltaTime, 0);
    }
}
