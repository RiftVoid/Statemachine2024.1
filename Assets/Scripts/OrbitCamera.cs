using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform focus;
    public float rotationSpeed = 100f;
    public float orbitDistance = 5f;
    public float minAngle = -20f;
    public float maxAngle = 90f;
    private Vector3 input;
    private Vector3 orbitAngle = new Vector3(45f, 0f, 0f);
    void Start()
    {
        
    }

    void Update()
    {
        input = new Vector3(-Input.GetAxis("Mouse Y"),
            Input.GetAxis("Mouse X"),
            0f);
    }

    private void LateUpdate()
    {
        orbitAngle += input * rotationSpeed * Time.deltaTime;
    }
}
