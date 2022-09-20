using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private float startPosition;

    public float moveSpeed;
    public float moveAmount;

    public SpawnArea spawnArea;

    public GameManager gameManager;


    private void Start()
    {
        startPosition = transform.position.x;
    }

    private void Update()
    {
        var newPosition = transform.position;
        newPosition.x = startPosition + Mathf.Sin(Time.time * moveSpeed) * moveAmount;
        transform.position = newPosition;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            int foodValue = collision.gameObject.GetComponent<Food>().value;
            gameManager.AddToScore(foodValue);
            spawnArea.SpawnTarget();
            Destroy(gameObject);
        }
    }
}
