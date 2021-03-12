using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittySpawner : MonoBehaviour
{
    public bool conditionsMet;
    [SerializeField] GameObject kittyPrefab;
    [SerializeField] float repeatRate;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnHappinness", 0, repeatRate);
    }

    void SpawnHappinness()
    {
        if (conditionsMet) Instantiate(kittyPrefab, this.transform);
    }
}
