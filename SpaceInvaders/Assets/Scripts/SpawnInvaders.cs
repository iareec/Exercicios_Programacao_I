using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInvaders : MonoBehaviour
{
    [SerializeField] GameObject[] Invaders;
    [SerializeField] GameObject[] InvadersInd;
    [SerializeField] int n_Invaders = 7; // Por linha
    [SerializeField] float minX = -3f;
    [SerializeField] float minY = -0.5f;
    [SerializeField] float xInc = 1f;
    [SerializeField] float yInc = 0.5f;
    [SerializeField] float probInd = 0.15f;
    private void Awake()
    {
        float y = minY;
        for (int i = 0; i < Invaders.Length; i++) // Número de linhas ocupadas pelos invaders
        {
            for (int j = 0; j < n_Invaders; j++) // Número de invaders por linha
            {
                GameObject normalOuIndestrutivel;
                if(Random.value < probInd)
                {
                    normalOuIndestrutivel = InvadersInd[i];
                } 
                else
                {
                    normalOuIndestrutivel = Invaders[i];
                }
                GameObject newInvader = Instantiate(normalOuIndestrutivel, transform);
                newInvader.transform.position = new Vector3(minX + j * xInc, y, 1f);
            }
            y += yInc; // Incrementação a cada nova linha
        }
    }
}

