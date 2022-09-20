using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBrush : MonoBehaviour
{
    public TrailRenderer paintTrailPrefab;

    public Renderer brushRenderer;

    private TrailRenderer currentTrail;

    public void StartPainting()
    {

        currentTrail = Instantiate(paintTrailPrefab, brushRenderer.transform);
        currentTrail.GetComponent<TrailRenderer>().material.color = brushRenderer.material.color;
    }

    public void StopPainting()
    {
        currentTrail.gameObject.transform.parent = null;
    }

    private void OnTriggerEnter(Collider paint)
    {

        Renderer paintRenderer = paint.GetComponent<Renderer>();

        if (paintRenderer != null)
        {
            brushRenderer.GetComponent<Renderer>().material.color = paintRenderer.material.color;
        }

    }

}
