using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject Car;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCar", 0f, 1f);
    }
    void SpawnCar()
    {
        if(Random.RandomRange(0, 5) < 4)
        {
            GameObject instance = Instantiate(Car, transform.position, transform.rotation);
            Destroy(instance, 8f);

        }
    }

}
