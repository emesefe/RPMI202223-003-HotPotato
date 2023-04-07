using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    private int randomNumber; // número aleatorio
    public int clickCounter; // contador

    private void Start()
    {
        randomNumber = Random.Range(1, 11); // Generamos número aleatorio entre 1 y 10 (el 11 no está incluido)
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddOneToCounter();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (HaveIWon())
            {
                Debug.Log("¡Eres un máquina!");
            }
        }
    }

    private void AddOneToCounter()
    {
        clickCounter++;
        transform.localScale += Vector3.one;
    }

    private bool HaveIWon()
    {
        bool haveIWon = false;
        if (clickCounter < randomNumber)
        {
            // Nos quedamos cortos
            Debug.Log($"Te has quedado corto. Has hecho {clickCounter} clicks y el número aleatorio era {randomNumber}");
        }else if (clickCounter == randomNumber)
        {
            // Acertamos
            Debug.Log("¡Has ganado!");
            haveIWon = true; // Cambiamos el valor false a true pues este es el caso en que ganamos
        }
        else
        {
            // Nos pasamos de largo
            Debug.Log("Te has pasado de largo.");
            Destroy(gameObject);
        }

        return haveIWon;
    }
}
