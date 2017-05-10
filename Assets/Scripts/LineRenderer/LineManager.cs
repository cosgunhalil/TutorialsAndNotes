using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineManager : MonoBehaviour {

    public List<Transform> CubeTransforms;

    private LineRenderer _lineRenderer;
 
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();

        DrawMap(CubeTransforms);
    }

    private void DrawMap(List<Transform> dots)
    {
        _lineRenderer.positionCount = dots.Count;

        for (int i = 0; i < dots.Count; i++)
        {
            _lineRenderer.SetPosition(i, dots[i].position);
        }
    }
}
