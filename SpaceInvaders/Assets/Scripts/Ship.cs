using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] GameObject fire;
    [SerializeField] Transform nozzle;
    [SerializeField] float velocidade = 5f;
    [SerializeField] int lives = 3;
    float minX, maxX;
    void Start()
    {
        // 0.25 é metade da metade do tamanho da nave
        minX = Camera.main.ViewportToWorldPoint(Vector2.zero).x + 0.25f;
        maxX = Camera.main.ViewportToWorldPoint(Vector2.one).x - 0.25f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(fire, nozzle.position, nozzle.rotation);
        }
        MoveShip();
    }
    void MoveShip()
    {
        float hMov = Input.GetAxis("Horizontal");
        transform.position += hMov * velocidade * Vector3.right * Time.deltaTime;

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        transform.position = position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        lives--;
        Debug.Log(lives);
        if (lives == 0)
        {
            Destroy(gameObject);
        }
    }
}
