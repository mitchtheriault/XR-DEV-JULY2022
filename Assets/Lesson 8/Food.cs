using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public float groundTimer = 5f;

    public int value = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            StartCoroutine("DestroyFood");
        }
    }

    IEnumerator DestroyFood()
    {
        yield return new WaitForSeconds(groundTimer);
        Destroy(gameObject); 
    }


}
