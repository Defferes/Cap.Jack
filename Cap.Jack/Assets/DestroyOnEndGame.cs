using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEndGame : MonoBehaviour
{
    public bool isFlag = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isFlag)
        {
            Destroy(other.gameObject);
        }
    }
}
