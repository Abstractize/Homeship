using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Player;
    public Material[] materials;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Throw() {
        GameObject bull = Instantiate(Bullet, transform.position, transform.rotation);
        bull.GetComponent<MeshRenderer>().material = materials[Random.Range(0, 4)];
        bull.GetComponent<Rigidbody>().AddForce(transform.forward * 20, ForceMode.Impulse);
        bull.GetComponent<Rigidbody>().MovePosition(this.GetComponent<Rigidbody>().position + transform.forward * 5f);
        Destroy(bull, 10f);
    }

    void AxisInput()
    {
        //Left
        if (Input.GetKey(KeyCode.A))
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0f, -30, 0f) * Time.deltaTime));
        }
        //Right
        if (Input.GetKey(KeyCode.D))
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0f, 30, 0f) * Time.deltaTime));
        }
    }

}
