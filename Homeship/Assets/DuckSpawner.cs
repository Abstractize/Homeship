using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    public GameObject Duck;
    public Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnDuck", 0f, 5f);
        //SpawnDuck();
    }

    void SpawnDuck()
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject instance = Instantiate(Duck, transform.position, transform.rotation);
            instance.GetComponent<MeshRenderer>().material = materials[Random.Range(0, 4)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
