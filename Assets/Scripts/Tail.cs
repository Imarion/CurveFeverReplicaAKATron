using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Tail : MonoBehaviour
{
    public float pointSpacing = .1f;
    public Transform snake; 

    LineRenderer line;
    EdgeCollider2D col2D;

    List<Vector2> points;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        col2D = GetComponent<EdgeCollider2D>();
        points = new List<Vector2>();
        SetPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(points.Last(), snake.position) > pointSpacing)
        {
            SetPoint();
        }
    }

    void SetPoint()
    {
        // Skip the newest point for the collider; this prevents colliding every frame
        col2D.points = points.ToArray<Vector2>();

        points.Add(snake.position);
        line.positionCount = points.Count();
        line.SetPosition(points.Count - 1, snake.position);
    }
}
