using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 
                                    0f,
                                    Input.GetAxis("Vertical"));
        if (input.magnitude > 1)
        {
            input.Normalize();
        }
        
        transform.position += input * speed * Time.deltaTime;
    }
}
