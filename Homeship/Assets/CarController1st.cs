using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController1st : MonoBehaviour
{
    public float moveSpeed = 10f;
    Vector3 init;

    // Start is called before the first frame update
    void Start()
    {

        init = new Vector3((float)-48.6, (float)3.54, (float)-34.9);
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
