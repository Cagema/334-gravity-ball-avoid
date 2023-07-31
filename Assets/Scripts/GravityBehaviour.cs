using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBehaviour : MonoBehaviour
{
    [SerializeField] float _gravityScale;
    private void Start()
    {
        SwipeDetection.SwipeEvent += OnSwipe;
    }

    private void OnSwipe(Vector2 direction)
    {
        Physics2D.gravity = direction * _gravityScale;
    }
}
