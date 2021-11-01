using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class MeteorMover : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody2D rigidBody;
    public bool IsBoos = false;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        if (!IsBoos)
        {
            rigidBody.velocity = new Vector2(0,speed );
        }
        else
        {
            rigidBody.velocity = new Vector2(speed,0 );
        }
    }
}
