using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameManager gameManager;
    public float speed = 10f;
    public float directionX = 0f;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(directionX, speed);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
            Destroy(other.gameObject);
            gameManager.AddScore();
            Destroy(gameObject);

    }
}
