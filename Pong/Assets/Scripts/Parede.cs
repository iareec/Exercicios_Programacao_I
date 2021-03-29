using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parede : MonoBehaviour
{
    public enum nomeParede {Esq, Dir}
    [SerializeField] Contador Pontuacao;
    [SerializeField] nomeParede lado = nomeParede.Esq;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Pontuacao.Golo(lado);
    }
}
