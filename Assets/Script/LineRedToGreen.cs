using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRedToGreen : MonoBehaviour
{

    public float _speed = 0.05f;
    public int lengthOfLineRenderer = 2;
    public Vector3 targetPosition;

    void FixedUpdate()
    {
        MoveObj();
    }
    void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        var points = new Vector3[lengthOfLineRenderer];
        points[0] = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        points[1] = new Vector3(-44.8f, 1.2f, 36f);
        lineRenderer.SetWidth(0.3f, 0.3f);
        lineRenderer.SetPositions(points);
    }
    void MoveObj()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-44.8f, 1.2f, 36f), _speed);
    }
}
