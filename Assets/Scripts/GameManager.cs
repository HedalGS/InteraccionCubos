using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TimeManager timeManager;
    private GameObject[] cubes;
    public List<bool> correctPosition = new List<bool>();
    void Start()
    {
        timeManager = GetComponent<TimeManager>();

        //Encontrar game objects con el tag Cube
        cubes  = GameObject.FindGameObjectsWithTag("Cube");
        

    }

    void Update()
    {
        //Asignar valores de correctPosition
        foreach (GameObject cube in cubes) {
            correctPosition.Add(cube.GetComponent<Cubes>().GetCorrectPosition());
        }

        //Verificar si todos los  valores de correctPosition son true
        if (AreAllTrue(correctPosition))
        {
            //Debug.Log("Ya esta :-)");
            timeManager.SetTimeRunning(false);
        }


        correctPosition.Clear(); //Para que no agregue infinitos valores
    }

    //Función para verificar todos los valores de List correctPosition
    bool AreAllTrue(List<bool> booleanArray)
    {
        foreach (bool value in booleanArray)
        {
            if (!value)
            {
                return false;
            }
        }
        return true;
    }
}
