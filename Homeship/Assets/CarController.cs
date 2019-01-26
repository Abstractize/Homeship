using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public float moveSpeed = 10f;
    Vector3 init;

    // Start is called before the first frame update
    void Start()
    {

        init = new Vector3((float)49.8, (float)3.54, (float)45.62);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("wall_brick"))
        {
            transform.position = init;
        }
    }
}
