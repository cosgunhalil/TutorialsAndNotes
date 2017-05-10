using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckableObject : MonoBehaviour {

	public Transform ObjectTransform;
	public Renderer ObjectRenderer;

	public void SetColor(Color color)
	{
		ObjectRenderer.material.color = color;
	}


}
