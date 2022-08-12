using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject explosion;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Instantiate(explosion, transform.position,transform.rotation);
            Destroy(collision.gameObject);
        }
    }
}
