using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed = 1f;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        Vector3 displacementFromTarget = target.position - _transform.position;
        float distanceToTarget = displacementFromTarget.magnitude;
        if (distanceToTarget > 1.5f) _transform.position = Vector3.MoveTowards(_transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    private void HandleRotation()
    {
        _transform.LookAt(target, Vector3.up);
    }
}
