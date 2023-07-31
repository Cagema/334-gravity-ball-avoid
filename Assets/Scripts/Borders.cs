using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    [SerializeField] Transform _left;
    [SerializeField] Transform _right;
    [SerializeField] Transform _up;
    [SerializeField] Transform _down;

    private void Start()
    {
        _left.transform.position = new Vector3(-GameManager.Single.RightUpperCorner.x, 0, 0);
        _right.transform.position = new Vector3(GameManager.Single.RightUpperCorner.x, 0, 0);
        _up.transform.position = new Vector3(0, GameManager.Single.RightUpperCorner.y, 0);
        _down.transform.position = new Vector3(0, -GameManager.Single.RightUpperCorner.y, 0);
    }
}
