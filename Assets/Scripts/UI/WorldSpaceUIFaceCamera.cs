using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceUIFaceCamera : MonoBehaviour
{
    public float smoothFactor = 10f;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update() 
    {
        Vector3 relativePos = transform.position - _camera.transform.position;

        Quaternion toRotation = Quaternion.LookRotation(relativePos);
        
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, smoothFactor * Time.deltaTime);
    }
}
