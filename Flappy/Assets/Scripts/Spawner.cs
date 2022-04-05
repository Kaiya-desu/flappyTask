using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private float maxTime;
    private float timer;
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float height;

    void Start()
    {
        GameObject spawnedPipe = Instantiate(pipePrefab);
        spawnedPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
        
        Destroy(spawnedPipe, 5); 
    }

    void Update()
    {
        if (timer > maxTime)
        {
            GameObject spawnedPipe = Instantiate(pipePrefab);
            spawnedPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);

            timer = 0;

            Destroy(spawnedPipe, 5); // niszczy sie po 5 sekundach - max jednoczesnie mamy 3 rury na mapie 
        }

        timer += Time.deltaTime;
    }
}
