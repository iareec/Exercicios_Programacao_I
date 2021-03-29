using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInvaders : MonoBehaviour
{
    [SerializeField] GameObject InvaderA;
    [SerializeField] GameObject InvaderB;
    [SerializeField] GameObject InvaderC;
    [SerializeField] int n_Invaders = 7; // Por linha
    [SerializeField] float minX = -3f;
    private void Awake()
    {
        GameObject[] Invaders = { InvaderA, InvaderB, InvaderC }; //Array com os invaders, de forma a não ter de criar um for para cada


        for (int i = 0; i < Invaders.Length; i++) // Tipos de invaders a serem criados
        {
            for (int j = 0; j < n_Invaders; j++) // Número de invaders por linha
            {
                for (int k = 0; k < 2; k++) // Duplica a linha
                {
                    GameObject newInvader = Instantiate(Invaders[i], transform);
                    newInvader.transform.position = new Vector3(minX + j * 1f, i+k * 0.5f - 0.5f, 0f);
                }
            }
        }
    }
}

