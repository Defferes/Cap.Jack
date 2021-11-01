using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class MotherMeteor : MonoBehaviour
{
    public GameManager _gameManager;
    public GameObject MeteorPrefab;
    public MeteorMover meteorMover;
    private SpriteRenderer _spriteRenderer;
    private int hp = 10;

    private void Start()
    {
        meteorMover.IsBoos = true;
        Spawn();
    }

    void Spawn()
    {
        Vector3 position = transform.position;
        Random rnd = new Random();
            position = position + new Vector3(-4f, rnd.Next(-1,2), 0f);
            Instantiate(MeteorPrefab, position, Quaternion.identity);
            position = position + new Vector3(0f, 2f, 0f);
            Instantiate(MeteorPrefab, position, Quaternion.identity);
            position = position + new Vector3(0f, -4f, 0f);
            Instantiate(MeteorPrefab, position, Quaternion.identity);
            Invoke("Spawn",1f);
                
    }

    void SwapColor(Color clr)
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = clr;
    }

    public void SwapColor()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = Color.white;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
            hp--;
            Destroy(other.gameObject);
            SwapColor(Color.red);
            Invoke("SwapColor",0.5f);
            if (hp == 0)
            {
                Destroy(gameObject);
                meteorMover.IsBoos = false;
                SceneManager.LoadScene("Main");
            }
    }
}
