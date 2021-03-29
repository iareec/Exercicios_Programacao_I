using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Contador : MonoBehaviour
{
    int pontuacaoEsq = 0;
    int pontuacaoDir = 0;

    [SerializeField] TextMeshProUGUI pontuacaoEsqTxt;
    [SerializeField] TextMeshProUGUI pontuacaoDirTxt;
    public void Golo(Parede.nomeParede collision)
    {
        if(collision == Parede.nomeParede.Dir) // Colisão com o lado direito
        {
            pontuacaoEsq += 1;
        } else if (collision == Parede.nomeParede.Esq) // Colisão com o lado esquerdo
        {
            pontuacaoDir += 1;
        }
        pontuacaoEsqTxt.text = pontuacaoEsq.ToString();
        pontuacaoDirTxt.text = pontuacaoDir.ToString();
        Debug.Log(pontuacaoEsq + " " + pontuacaoDir);
    }
}
