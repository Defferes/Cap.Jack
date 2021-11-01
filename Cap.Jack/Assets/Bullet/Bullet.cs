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
        if (!gameManager.IsBoos)
        {
            rigidBody.velocity = new Vector2(directionX, speed );
        }
        else
        {
            rigidBody.velocity = new Vector2(speed, directionX);
        }
        
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Meteor(Clone)")
        {
            Destroy(other.gameObject);
            gameManager.AddScore();
            Destroy(gameObject);
        }
    }
}
