using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarActorCollection : MonoBehaviour 
{


    [SerializeField]
    private List<GameObject> carPrefabs = new List<GameObject>();

    [SerializeField]
    private GameObject busPrefab;


    private static GameObject staticbusPrefab;

    public static List<GameObject> StaticCarPrefabs { get; private set; }

    private void Awake()
    {
        StaticCarPrefabs = new List<GameObject>(carPrefabs);
    }

    // Static method to get a random GameObject from the list
    public static GameObject GetRandomCarPrefab()
    {
        if (StaticCarPrefabs.Count == 0)
        {
            Debug.LogError("No car prefabs available.");
            return null;
        }
        int randomIndex = Random.Range(0, StaticCarPrefabs.Count);
        return StaticCarPrefabs[randomIndex];
    }
    public static GameObject GetBussprefab()
    {

        return staticbusPrefab;
    }


}
