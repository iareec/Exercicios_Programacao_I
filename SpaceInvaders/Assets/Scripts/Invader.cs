using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField] GameObject fire = null;
    [SerializeField] float cadencia; // Cadência sendo 1f o valor inicial
    [SerializeField] float cadenciaMin = 2f; // Valor mínimo de cadência 
    [SerializeField] float cadenciaMax = 6f; // Valor máximo de cadência
    [SerializeField] int protection = 10; // Proteção do invasor, após levar 10 tiros, é destruído
    float tempoQuePassou;
    private void Start()
    {
        cadencia = Random.value * (cadenciaMax - cadenciaMin) + cadenciaMin;
        Debug.Log(cadencia);
    }
    private void Update()
    {
        if (tag == "Destrutivel")
        {
            tempoQuePassou += Time.deltaTime;
            if (tempoQuePassou >= cadencia)
            {
                Instantiate(fire, transform.position, transform.rotation);
                tempoQuePassou = 0f;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Destrutivel")
        {
            if (collision.gameObject.tag == "DisparoNave")
            {
                Destroy(gameObject); // Auto-destruição
                Destroy(collision.gameObject); // Destruição do objeto que atinge
            }
        } 
        if (tag == "Indestrutivel")
        {
            protection--; 
            Destroy(collision.gameObject);
            if (protection == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
