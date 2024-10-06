using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Spawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 3;
    public float lastSpawnTime = 0;

    private void Start() 
    {
        Instantiate(pipePrefab);
    }
    
    void Update()
    {
        if(Time.time >= lastSpawnTime + spawnRate)
        {
            var pos = transform.position;
            pos.y += Random.Range(0, 4f);
            pos.x += Random.Range(-1f, 1.1f);

            Instantiate(pipePrefab, pos, Quaternion.identity);
            lastSpawnTime = Time.time;
        }
    }
}
