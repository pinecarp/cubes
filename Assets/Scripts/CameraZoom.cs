using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private float _zoomSpeed;
    private float _barrierMax;
    private float _barrierMin;

    private void Start()
    {
        _zoomSpeed = 50.0f;
        _barrierMax = 50.0f;
        _barrierMin = 10.0f;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.position += transform.forward * _zoomSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position -= transform.forward * _zoomSpeed * Time.deltaTime;
        }
        
        if (transform.position.y > _barrierMax)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, _barrierMax, -_barrierMax), 10);
        }
        if (transform.position.y < _barrierMin)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, _barrierMin, -_barrierMin), 10);
        }
    }
}
