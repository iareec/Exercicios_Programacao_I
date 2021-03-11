using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeCartas : MonoBehaviour
{
    string[] naipe = new string[] {"Paus", "Ouros", "Copas", "Espadas"};
    string[] valor = new string[] {"o Ás", "o 2", "o 3", "o 4", "o 5", "o 6", "o 7", "o 8", "o 9", "o 10", "o Valete", "a Dama", "o Rei"};
    void Start()
    {
        Iniciar();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GerarCarta();
        }
    }
    void Iniciar() 
    {
        Debug.Log("Pressione na barra de espaço para gerar uma nova carta.");
    }
    void GerarCarta() 
    {
        string naipe_sorteado = naipe[Random.Range(0, naipe.Length)];
        string valor_sorteado = valor[Random.Range(0, valor.Length)];
        Debug.Log("Saiu " + valor_sorteado + " de " + naipe_sorteado + "!");
        Iniciar();
    }
}
