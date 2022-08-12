using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{

    public Transform objectToRotate;

    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        objectToRotate.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

}
