using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeRotator : MonoBehaviour
{
    private float _rotationSpeed;
    private float _inputX;
    private float _inputY;

    void Start()
    {
        _rotationSpeed = 100.0f;
    }

    void Update()
    {
        _inputX = Input.GetAxis("Horizontal");
        _inputY = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.down * _inputX * _rotationSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right * _inputY * _rotationSpeed * Time.deltaTime, Space.World);
    }
}
