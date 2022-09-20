using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    public UnityEvent OnPushed;
    public float startPosition;
    public float maxPushDistance;

    public bool wasPushed = false;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.localPosition;
        position.x = 0;
        position.z = 0;

        float minPosition = startPosition - maxPushDistance;
        position.y = Mathf.Clamp(position.y, minPosition, maxPushDistance);
        transform.localPosition = position;

        float pushDistanceThreshold = (startPosition - minPosition) * 0.3f;

        if (wasPushed == false && position.y < minPosition + pushDistanceThreshold)
        {
            wasPushed = true;
            OnPushed.Invoke();
        }
        else if (wasPushed == true && position.y > startPosition - pushDistanceThreshold)
        {
            wasPushed = false;
        }
    }
}
