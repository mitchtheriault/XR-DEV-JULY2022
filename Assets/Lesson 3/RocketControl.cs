using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControl : MonoBehaviour
{
    private Rigidbody m_rigidbody;

    [SerializeField]
    private float thrust;
    [SerializeField]
    private float turningThrust;

    public GameObject laserPrefab;
    public Transform laserSpawnPoint;

    public float laserSpeed;


    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_rigidbody.AddRelativeForce(Vector3.forward * thrust, ForceMode.Force);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //instantiate the laser!
            ShootLaser();
        }

        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            m_rigidbody.AddRelativeTorque(0f, mouseX * turningThrust * Time.deltaTime, 0f);
            m_rigidbody.AddRelativeTorque(mouseY * -turningThrust * Time.deltaTime, 0f, 0f);

        }
    }

    void ShootLaser()
    {
        print("shooting laser!");
        GameObject laserClone = Instantiate(laserPrefab,laserSpawnPoint.position,laserSpawnPoint.rotation);
        Rigidbody laserCloneRb = laserClone.GetComponent<Rigidbody>();
        laserCloneRb.AddRelativeForce(Vector3.forward * laserSpeed, ForceMode.Impulse);
    }

}
