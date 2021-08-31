using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObjects : MonoBehaviour
{
    public GameObject toSpawn;
    private GameObject spawnedObj;
    public float objectSpeed;

    void spawnObj()
    {
        for (int i = 0; i < 3; i++)
        {

            spawnedObj = Instantiate(toSpawn, transform.position, transform.rotation);
            

        }
    }

    private void Start()
    {
        spawnObj();
    }

    private void Update()
    {
        if (spawnedObj == null)
        {
            return;
        }
        spawnedObj.transform.position = Vector3.forward * objectSpeed * Time.deltaTime;
    }
}
