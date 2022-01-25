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
    private float _resetTime;

    public bool _isReset;
    
    void Start()
    {
        _rotationSpeed = 100.0f;
        _resetTime = 5f;
    }

    void Update()
    {
        _inputX = Input.GetAxis("Horizontal");
        _inputY = Input.GetAxis("Vertical");

        if (_isReset == false)
        {
            transform.Rotate(Vector3.down * _inputX * _rotationSpeed * Time.deltaTime, Space.World);
            transform.Rotate(Vector3.right * _inputY * _rotationSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reset());
        }
    }

    private void FixedUpdate()
    {
        if (_isReset)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, _resetTime * Time.deltaTime);
        }
    }

    private IEnumerator Reset()
    {
        _isReset = true;
        yield return new WaitForSeconds(1);
        _isReset = false;
    }
}
