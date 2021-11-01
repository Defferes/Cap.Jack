using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackgroundRight : MonoBehaviour
{
    public float speed = -2f;
    public float lowerXValue = -20f;
    public float upperXValue = 40;
    void Update()
    {
        transform.Translate(0f,speed*Time.deltaTime,0f);
        if (transform.position.x <= lowerXValue)
        {
            transform.Translate(0f, upperXValue, 0f);
        }
    }
}
