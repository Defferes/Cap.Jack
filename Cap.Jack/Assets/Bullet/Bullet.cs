using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    GameManager gameManager;
    public bool IsTriple = false;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        if (!IsTriple)
        {
            rigidBody.velocity = new Vector2(0f, speed);
        }
        else
        {
            rigidBody.velocity = new Vector2(2f,speed);
        }
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);
        gameManager.AddScore();
        Destroy(gameObject); 
    }
}
