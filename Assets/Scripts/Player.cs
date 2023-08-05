using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Bonus _bonus;
    Rigidbody2D _rb;
    SpriteRenderer _sr;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (Physics2D.gravity.x < 0)
        {
            _sr.flipX = true;
        }
        else
        {
            _sr.flipX = false;
        }
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
