using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestPhysBut : MonoBehaviour
{

    public UnityEvent OnPushed;
    public float startPosition;
    public float maxPushDistance;

    public bool wasPushed = false;

    private void Start()
    {
        startPosition = transform.localPosition.y;
    }


    // Update is called once per frame
    void Update()
    {
        var position = transform.localPosition;
        position.x = 0;
        position.z = 0;
        float minPosition = startPosition - maxPushDistance;
        position.z = Mathf.Clamp(position.z, minPosition, startPosition);
        transform.localPosition = position;

        float pushDistanceThreshold = (startPosition - minPosition) * 0.4f;

        if (!wasPushed && position.y < minPosition + pushDistanceThreshold)
        {
            wasPushed = true;
            OnPushed.Invoke();
        }
        else if (wasPushed && position.y > startPosition - pushDistanceThreshold)
        {
            wasPushed = false;
        }

    }
}
