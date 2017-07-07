using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionDetector : MonoBehaviour {

    private List<LineSegment> _lineSegments;

    void Start()
    {
        InitLineSegments();

		var intersect = Vector2.zero;

        IsIntersect(_lineSegments[0].P1, _lineSegments[0].P2, 
                    _lineSegments[1].P1, _lineSegments[1].P2, 
                    out intersect);

		Debug.Log(intersect);

        VisualizeLineSegments(_lineSegments);
    }

    private void InitLineSegments()
    {
        var l1 = new LineSegment();
        l1.CreateLineSegment(new Vector2(2,3), new Vector2(5,5));

        var l2 = new LineSegment();
        l2.CreateLineSegment(new Vector2(3, 5), new Vector2(5, 1));

        _lineSegments = new List<LineSegment>();
        _lineSegments.Add(l1);
        _lineSegments.Add(l2);

    }

    private bool IsIntersect(Vector2 p, Vector2 p2, Vector2 q, Vector2 q2, out Vector2 intersection, bool considerCollinearOverlapAsIntersect = false)
    {
        intersection = new Vector2(0, 0);

        var r = p2 - p;
        var s = q2 - q;
        var rxs = Cross(r, s);
        var qpxr = Cross((q - p), r);

        if (IsZero(rxs) && IsZero(qpxr))
		{
			if (considerCollinearOverlapAsIntersect)
                if ((0 <= Multiply((q - p),r) && Multiply((q - p), r) <= Multiply(r,r)) || 
                    (0 <= Multiply((p - q) , s) && Multiply((p - q) , s) <= Multiply(s , s)))
					return true;

			return false;
		}


        if (IsZero(rxs) && !IsZero(qpxr))
			return false;
        
        var t = Cross((q - p), s) / rxs; 
        var u = Cross((q - p), r) / rxs; 

        if (!IsZero(rxs) && (0 <= t && t <= 1) && (0 <= u && u <= 1))
		{
			intersection = p + t * r;
			return true;
		}


        return false;
    }

    private  bool IsZero(float val)
    {
        return Mathf.Abs(val) < Mathf.Epsilon;
    }

    public float Cross(Vector2 v1, Vector2 v2)
	{
        return v1.x * v2.y - v1.y * v2.x;
	}

    public float Multiply(Vector2 v1, Vector2 v2)
    {
        return v1.x * v2.x + v1.y * v2.y;
    }

    public void VisualizeLineSegments(List<LineSegment> lineSegments)
    {
        foreach (var lineSegment in lineSegments)
        {
            var lineView = new GameObject("Line(" + lineSegment.P1 + "," + lineSegment.P2 + ")");
            lineView.AddComponent<LineRenderer>();

            var lineRenderer = lineView.GetComponent<LineRenderer>();
            lineRenderer.startWidth = .1f;

            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, lineSegment.P1);
            lineRenderer.SetPosition(1, lineSegment.P2);
        }
    }

}

public struct LineSegment
{
    public Vector2 P1;
    public Vector2 P2;

    public void CreateLineSegment(Vector2 p1, Vector2 p2)
    {
        P1 = p1;
        P2 = p2;
    }
}
