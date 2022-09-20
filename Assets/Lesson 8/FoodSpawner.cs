using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public List<GameObject> possibleFoods = new List<GameObject>();

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hands")
        {
            int randomIndex = Random.Range(0, possibleFoods.Count);
            Instantiate(possibleFoods[randomIndex], transform.position, transform.rotation);
        }
    }
}
