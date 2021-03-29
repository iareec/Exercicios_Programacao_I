using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    [SerializeField] float velocidade = 5f;
    bool lancamento = false;
    void Update()
    {
        float cronometro = Time.time;
        if (cronometro > 2.0 && lancamento == false)
        {
            lancamento = true;
            lancarBola();
        }
    }
    void lancarBola()
    {
        GetComponent<Rigidbody2D>().velocity = velocidade * Random.onUnitSphere; // Lança para um lado aleatório (-1 a 1, -1 a 1)
    }
}
