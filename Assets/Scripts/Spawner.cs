using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2;

    private float lastSpawnTime;


    void Start()
    {
        //Instantiate - create a new object from a prefab
        Instantiate(pipePrefab);
    }

    
    void Update()
    {
        if(Time.time > lastSpawnTime + spawnRate)
        {
            Instantiate(pipePrefab);
            lastSpawnTime = Time.time;
        }
    }
}
