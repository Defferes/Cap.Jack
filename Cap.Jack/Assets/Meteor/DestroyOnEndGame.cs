using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEndGame : MonoBehaviour
{
    public bool isFlag = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isFlag == true && (other.gameObject.name == "Meteor(Clone)" || other.gameObject.name == "Box(Clone)"))
        {
            Destroy(other.gameObject);
        }
    }
}
