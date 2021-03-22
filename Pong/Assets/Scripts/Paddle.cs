using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float velocidade = 2f;
    [SerializeField] KeyCode setaCima = KeyCode.UpArrow;
    [SerializeField] KeyCode setaBaixo = KeyCode.DownArrow;

    void Update()
    {
        if (Input.GetKey(setaCima)) // Seta para cima, sobe
        {
            transform.position += velocidade * Vector3.up * Time.deltaTime;
        } if (Input.GetKey(setaBaixo)) // Seta para baixo, desce
        {
            transform.position += velocidade * Vector3.down * Time.deltaTime;
        }
        float alturaCamera = Camera.main.orthographicSize;
        Vector3 posicaoAux = transform.position;
        posicaoAux.y = Mathf.Clamp(posicaoAux.y, -alturaCamera + 0.5f, alturaCamera - 0.5f);
        transform.position = posicaoAux;
    }
}
