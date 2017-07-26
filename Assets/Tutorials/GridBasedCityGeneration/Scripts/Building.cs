using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, IBuilding
{
    public GameObject FloorPrefab;
    public int FloorCount
    {
        get
        {
            return _floorCount;
        }

        set
        {
            if (_floorCount != value)
            {
				_floorCount = value;
				SetFloorCount(_floorCount);
            }
           
        }
    }

    private int _floorCount;

    public EBuildingType BuildingType 
    { 
        get
        {
            return _buildingType;
        } 

        set
        {
            if (_buildingType != value)
            {
                _buildingType = value;
            }
        }
    }

    public float FloorHeight
    {
        get
        {
            return _floorHeight;
        }

        set
        {
            if (_floorHeight != value)
            {
                _floorHeight = value;
            }
        }
    }

    private float _floorHeight;

    private List<GameObject> _floorPool;

    private EBuildingType _buildingType;

    private Transform _transform;

    private List<Grid> _grids;

	public void Init()
	{
        FloorHeight = 1;
        _floorPool = new List<GameObject>();
        _grids = new List<Grid>();
        _transform = GetComponent<Transform>();
	}

    public void Place(Vector3 position, List<Grid> gridList)
    {
        _transform.position = position;
        _grids.AddRange(gridList);
    }

    public void SetFloorCount(int floorCount)
    {
		//TODO reset floors if floorList count is greater then 0 
		for (int i = 1; i < floorCount + 1; i++)
        {
            var currentPosition = _transform.position + new Vector3(0,i * FloorHeight, 0);
			var floor = GetFloorFromPool();
			floor.transform.position = currentPosition;
            floor.transform.parent = _transform;
        }
    }

    private GameObject GetFloorFromPool()
    {
        if (_floorPool.Count == 0)
        {
            _floorPool.Add(GenerateFloor());
        }

        var f = _floorPool[_floorPool.Count - 1];
        _floorPool.Remove(f);

        return f;
    }

    private GameObject GenerateFloor()
    {
        return Instantiate(FloorPrefab) as GameObject;
    }
}
