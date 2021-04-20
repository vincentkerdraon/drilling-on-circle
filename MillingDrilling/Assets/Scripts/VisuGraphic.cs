using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisuGraphic : MonoBehaviour
{
    public const int RADIUS = 15;
    public Vector3 ORIGIN = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        DrawCircle(gameObject, RADIUS, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawCircle(GameObject container, float radius, float lineWidth)
    {
        var segments = 360;
        var line = container.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;
        line.positionCount = segments + 1;

        var pointCount = segments + 1; // add extra point to make startpoint and endpoint the same to close the circle
        var points = new Vector3[pointCount];

        for (int i = 0; i < pointCount; i++)
        {
            var rad = Mathf.Deg2Rad * (i * 360f / segments);
            points[i] = new Vector3(Mathf.Sin(rad) * radius, 0, Mathf.Cos(rad) * radius);
        }

        line.SetPositions(points);
    }

}
