using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject Bullet;
    public Material[] materials;

    public void Throw() {
        GameObject bull = Instantiate(Bullet, transform.position, transform.rotation);
        bull.GetComponent<MeshRenderer>().material = materials[Random.Range(0, 4)];
        bull.GetComponent<Rigidbody>().AddForce(Vector3.forward * 20, ForceMode.Impulse);
        Destroy(bull, 10f);
    }

}
