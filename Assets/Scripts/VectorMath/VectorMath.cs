using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMath : MonoBehaviour {

	public Transform StartPoint;
	public Transform EndPoint;
	public Transform Pointer;

	public CheckableObject CheckedObject;

	public LineRenderer LineRenderer;
	
	// Update is called once per frame
	void Update () 
	{
		var distance = Vector3.Distance(EndPoint.position,StartPoint.position);
		var vector = EndPoint.position - StartPoint.position;
		var normalized = Vector3.Normalize (vector);


		Pointer.position = EndPoint.position + distance * normalized;

		LineRenderer.positionCount = 3;

		LineRenderer.SetPosition (0, StartPoint.position);
		LineRenderer.SetPosition (1, EndPoint.position);
		LineRenderer.SetPosition (2, Pointer.position);

		var position = Mathf.Sign ((EndPoint.position.x - StartPoint.position.x) * (CheckedObject.ObjectTransform.position.y - StartPoint.position.y) -
		               (EndPoint.position.y - StartPoint.position.y) * (CheckedObject.ObjectTransform.position.x - StartPoint.position.x));
		if (position > 0) 
		{
			CheckedObject.SetColor (Color.yellow);
		} 
		else 
		{
			CheckedObject.SetColor (Color.magenta);	
		}

	}
		
}
