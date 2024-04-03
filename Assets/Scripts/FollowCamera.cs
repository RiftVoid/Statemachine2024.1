using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Update = UnityEngine.PlayerLoop.Update;

public class FollowCamera : MonoBehaviour
{
    public Transform follow;
    public float cameraHeight = 5f;
    public Vector2 cameraOffset;

    private Vector3 focus;

    private void Start()
    {
        focus = follow.position;
    }

    private void LateUpdate()
    {
        Vector3 offset = new Vector3(cameraOffset.x, 0f, cameraOffset.y);
        transform.position = focus + (Vector3.up * cameraHeight) + offset;
        transform.LookAt(focus);
        FocusUpdate();
    }

    private Vector3 velocity;
    private void FocusUpdate()
    {
        if (Vector3.Distance(focus, transform.position) > 5f)
        {
            focus = Vector3.SmoothDamp(focus, follow.position, ref velocity, 1f);
        }
    }
}
