using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Bonus _bonus;
    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void StartFall()
    {
        _rb.gravityScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            GameManager.Single.Score++;
            if (!_bonus) _bonus = collision.GetComponent<Bonus>();
            _bonus.SetNewPos();
        }
        else if (collision.CompareTag("Enemy"))
        {
            GameManager.Single.Lives--;
            Destroy(gameObject);
        }
    }
}
