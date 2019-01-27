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

        init = transform.position;
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
            Destroy(this);
        }
        if(collision.gameObject.name == "Player 1")
        {
            collision.gameObject.GetComponent<Rigidbody>().MovePosition(new Vector3(5.979043f, 2.1f, -48.9f));
        }
    }
}
