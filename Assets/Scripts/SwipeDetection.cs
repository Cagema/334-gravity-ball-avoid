using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public static event OnSwipeInput SwipeEvent;
    public delegate void OnSwipeInput(Vector2 direction);

    Vector2 _tapPos;
    Vector2 _swipeDelta;

    float _deadZone = 80;

    bool _isSwiping;
    bool _isMobile;

    private void Start()
    {
        _isMobile = Application.isMobilePlatform;
    }

    private void Update()
    {
        if (GameManager.Single.GameActive)
        {
            if (!_isMobile)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _isSwiping = true;
                    _tapPos= Input.mousePosition;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    ResetSwipe();
                }
            }
            else
            {
                if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        _isSwiping = true;
                        _tapPos = Input.GetTouch(0).position;
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Canceled || 
                        Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        ResetSwipe();
                    }
                }
            }

            CheckSwipe();
        }
    }

    private void CheckSwipe()
    {
        if (_isSwiping)
        {
            if (!_isMobile && Input.GetMouseButton(0))
            {
                _swipeDelta = (Vector2)Input.mousePosition - _tapPos;
            }
            else if (Input.touchCount > 0)
            {
                _swipeDelta = Input.GetTouch(0).position - _tapPos;
            }
        }

        if (_swipeDelta.magnitude > _deadZone)
        {
            SwipeEvent?.Invoke(_swipeDelta.normalized);

            ResetSwipe();
        }
    }

    private void ResetSwipe()
    {
        _isSwiping = false;

        _tapPos = Vector2.zero;
        _swipeDelta = Vector2.zero;
    }
}
