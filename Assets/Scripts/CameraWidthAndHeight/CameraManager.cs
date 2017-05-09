using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    public Camera MainCamera;

	void Start ()
    {
        float height = 2f * MainCamera.orthographicSize;
        float width = height * MainCamera.aspect;

        Debug.Log("Height = " + height + " / Width = " + width);
    }
	
}
