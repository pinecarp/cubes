using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeRotator : MonoBehaviour
{
    private float _rotationSpeed = 5f;

    private Quaternion _newRotation = Quaternion.identity;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {       
            _newRotation *= Quaternion.AngleAxis(90, Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {       
            _newRotation *= Quaternion.AngleAxis(-90, Vector3.up);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _newRotation, _rotationSpeed * Time.deltaTime);
    }
}
