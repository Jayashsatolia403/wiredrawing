# wiredrawing

using UnityEngine;

public class WireDrawing : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 mousePos;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, mousePos);
    }
}
