using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject bulletPrefab;
    public float speed = 10f;
    public float xLimit = 7f;
    public float yLimit = 7f;
    public float reloadTime = 0.5f;
    private float elapsedTime = 0f;
    public int hearts = 2;
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        transform.Translate(xInput * speed * Time.deltaTime, yInput * speed * Time.deltaTime, 0f);
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -xLimit, xLimit);
        position.y = Mathf.Clamp(position.y, -yLimit, yLimit);
        transform.position = position;
        if (Input.GetButtonDown("Jump") && elapsedTime > reloadTime)
        {
            Vector3 spawnPos = transform.position;
            spawnPos += new Vector3(0, 1.2f, 0);
            Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
            elapsedTime = 0f; 
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        hearts--;
        gameManager.Hearts(hearts);
        if (hearts == 0)
        {
            gameManager.PlayerDied();
        }
    }
}
