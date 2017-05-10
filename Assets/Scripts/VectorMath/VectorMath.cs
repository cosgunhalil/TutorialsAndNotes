using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMath : MonoBehaviour {

	public Transform StartPoint;
	public Transform EndPoint;
	public Transform Pointer;

	public CheckableObject CheckedObject;

	public LineRenderer LineRenderer;

    private float _distance;
    private Vector3 _vector;
    private Vector3 _normalizedVector;

	void Update () 
	{
        CalculateParameters();
        SetPointerPosition();
        DrawLine();

        var position = CalculateDotPositionSign();

		if (position > 0) 
		{
			CheckedObject.SetColor (Color.yellow);
		} 
		else 
		{
			CheckedObject.SetColor (Color.magenta);	
		}

	}

    private void CalculateParameters()
    {
        _distance = Vector3.Distance(EndPoint.position, StartPoint.position);
        _vector = EndPoint.position - StartPoint.position;
        _normalizedVector = Vector3.Normalize(_vector);
    }

    private void SetPointerPosition()
    {
        Pointer.position = EndPoint.position + _distance * _normalizedVector;
    }

    private void DrawLine()
    {
        LineRenderer.positionCount = 3;

        LineRenderer.SetPosition(0, StartPoint.position);
        LineRenderer.SetPosition(1, EndPoint.position);
        LineRenderer.SetPosition(2, Pointer.position);
    }

    private float CalculateDotPositionSign()
    {
        var sign = Mathf.Sign((EndPoint.position.x - StartPoint.position.x) *
                   (CheckedObject.ObjectTransform.position.y - StartPoint.position.y) -
                   (EndPoint.position.y - StartPoint.position.y) *
                   (CheckedObject.ObjectTransform.position.x - StartPoint.position.x));

        return sign;
    }
}
