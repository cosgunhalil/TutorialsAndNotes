using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {

    public CubeMeshGenerator CubeGenerator;
    public CameraLerpManager FollowerCamera;

    //private List<Cube> _cubeTower;

    private Stack<Cube> _cubeTower;

	// Use this for initialization
	void Start () {

        _cubeTower = new Stack<Cube>();

	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
            SetNewFloor(CubeGenerator.CreateCube());
		}
	}

    private void SetNewFloor(GameObject floor)
    {
        var floorView = floor.GetComponent<Cube>();

        var floorPosition = Vector3.zero;

        if(_cubeTower.Count > 0)
        {
            var latestFloor = _cubeTower.Peek();
            floorPosition = latestFloor.GetTransform().position;
            floorPosition += new Vector3(0, floorView.GetWidth() / 2 + latestFloor.GetWidth() / 2 + 2, 0);
        }

        floorView.SetPosition(floorPosition);

        _cubeTower.Push(floorView);
        FollowerCamera.SetTarget(floorView.GetTransform());
    }
}
