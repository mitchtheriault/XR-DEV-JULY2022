using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FoodLauncher : MonoBehaviour
{
    public GameObject foodToLaunch;
    public Transform spawnPoint;

    public float shootStrength = 1f;

    public XRSocketInteractor socket;

    public void Shoot()
    {
        if (foodToLaunch != null)
        {
            var foodClone = Instantiate(foodToLaunch, spawnPoint.position, spawnPoint.rotation);
            Rigidbody foodCloneRb = foodClone.GetComponent<Rigidbody>();
            foodCloneRb.useGravity = true;
            foodCloneRb.isKinematic = false;
            foodCloneRb.AddRelativeForce(Vector3.forward * shootStrength, ForceMode.Impulse);
        }
    }

    public void SetFoodItem()
    {
        foodToLaunch = socket.firstInteractableSelected.transform.gameObject;
    }

}
