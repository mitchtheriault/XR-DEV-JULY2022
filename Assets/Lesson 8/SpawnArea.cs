using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{

    public GameObject targetPrefab;

    public BoxCollider spawnAreaCollider;

    public GameManager gameManager;

    private void Start()
    {
        spawnAreaCollider = GetComponent<BoxCollider>();
    }

    public void SpawnTarget()
    {
        GameObject spawnedTarget = Instantiate(targetPrefab,GetRandomPosition(),targetPrefab.transform.rotation);
        spawnedTarget.GetComponent<Target>().spawnArea = this;
        spawnedTarget.GetComponent<Target>().gameManager = gameManager;
    }

    Vector3 GetRandomPosition()
    {
        var xValue = Random.Range(spawnAreaCollider.bounds.min.x, spawnAreaCollider.bounds.max.x);
        var yValue = Random.Range(spawnAreaCollider.bounds.min.y, spawnAreaCollider.bounds.max.y);
        var zValue = Random.Range(spawnAreaCollider.bounds.min.z, spawnAreaCollider.bounds.max.z);

        return new Vector3(xValue, yValue, zValue);
    }

}
