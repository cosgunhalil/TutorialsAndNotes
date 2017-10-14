using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//http://www.habrador.com/tutorials/unity-mesh-combining-tutorial/

public class CameraController : MonoBehaviour {

    private float _height = 40f;
	private float _distanceBack = 40f;

	private float _cameraMovementSpeed = 30f;
	private float _zoomSpeed = 3f;

    private Transform _transform;

	void Start()
	{
        _transform = GetComponent<Transform>();

        SetupCamera();
	}

    private void SetupCamera()
    {
        _transform.position = new Vector3(0,0,0);
		_transform.position += new Vector3(0f, _height, 0f);
		_transform.position -= new Vector3(0f, 0f, _distanceBack);
        _transform.LookAt(new Vector3(0,0,0));
    }

    void LateUpdate()
	{
        HandleCameraMovement();
        HandleCameraZoom();
	}

    private void HandleCameraMovement()
    {
		if (Input.GetKey(KeyCode.A))
		{
			_transform.position -= new Vector3(_cameraMovementSpeed * Time.deltaTime, 0f, 0f);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			_transform.position += new Vector3(_cameraMovementSpeed * Time.deltaTime, 0f, 0f);
		}

		if (Input.GetKey(KeyCode.S))
		{
            _transform.position -= new Vector3(0f, 0f, _cameraMovementSpeed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.W))
		{
            _transform.position += new Vector3(0f, 0f, _cameraMovementSpeed * Time.deltaTime);
		}
    }

	private void HandleCameraZoom()
	{
		float currentHeight = transform.position.y;

		float zoomDistance = 0f;

		if (currentHeight > 20f && currentHeight < 200f)
		{
			if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetKeyDown(KeyCode.I))
			{
				zoomDistance += _zoomSpeed;
			}
			else if (Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetKeyDown(KeyCode.O))
			{
				zoomDistance -= _zoomSpeed;
			}
		}
		else if (currentHeight > 200f)
		{
			if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetKeyDown(KeyCode.I))
			{
				zoomDistance += _zoomSpeed;
			}
		}
		else if (currentHeight < 20f)
		{
			if (Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetKeyDown(KeyCode.O))
			{
				zoomDistance -= _zoomSpeed;
			}
		}

		_transform.Translate(Vector3.forward * zoomDistance);
	}

}
