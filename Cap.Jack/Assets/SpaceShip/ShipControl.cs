using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

enum TypeShooting
{
    single,
    triple
}
public class ShipControl : MonoBehaviour
{
    private TypeShooting _typeShooting = TypeShooting.single;
    public GameManager gameManager;
    public GameObject bulletPrefab;
    public Bullet bulletManger;
    private SpriteRenderer _spriteRenderer;
    public float speed = 10f;
    public float xLimit = 7f;
    public float yLimit = 7f;
    public float reloadTime = 0.5f;
    private float elapsedTime = 0f;
    public int countHearts = 2;
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        transform.Translate(xInput * speed * Time.deltaTime, yInput * speed * Time.deltaTime, 0f);
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -xLimit, xLimit);
        position.y = Mathf.Clamp(position.y, -yLimit, yLimit);
        transform.position = position;
        if(Input.GetKey(KeyCode.F1))
        {
            _typeShooting = TypeShooting.single;
        }
        if(Input.GetKey(KeyCode.F2))
        {
            _typeShooting = TypeShooting.triple;
        }
        if (Input.GetButtonDown("Jump") && elapsedTime > reloadTime)
        {
            Vector3 spawnPos = transform.position;
            spawnPos += new Vector3(0f, 1.2f, 0);
            if (_typeShooting == TypeShooting.single)
            {
                SingleShoot(spawnPos);
            }
            else if (_typeShooting == TypeShooting.triple)
            {
                TripleShoot(spawnPos);
            }
            
        }
    }

    void SingleShoot(Vector3 spawnPos)
    {
        bulletManger.directionX = 0f;
        Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        elapsedTime = 0f; 
    }

    void TripleShoot(Vector3 spawnPos)
    {
        
        bulletManger.directionX = 0f;
        Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        bulletManger.directionX = 2f;
        Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        bulletManger.directionX = -2f;
        Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        elapsedTime = 0f; 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Meteor(Clone)")
        {
            SwapColor(Color.red);
            Invoke("SwapColor",0.5f);
            Destroy(other.gameObject);
            countHearts--;
            gameManager.WriteHearts(countHearts);
            if (countHearts == 0)
            {
                gameManager.PlayerDied();
            }
        }
        if (other.gameObject.name == "Box(Clone)")
        {
            Destroy(other.gameObject);
            if (Random.Range(0, 2) == 0)
            {
                _typeShooting = TypeShooting.triple;
                Invoke("ReturnSingleShooting",5f);
            }
            else
            {
                countHearts++;
                gameManager.WriteHearts(countHearts);
            }
        }
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

    void ReturnSingleShooting()
    {
        _typeShooting = TypeShooting.single;
    }
}
