using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityController : MonoBehaviour {

    public Camera MainCamera;
    public CityGenerator CityFactory;

    [Range(0f, 100f)]
    public float BuildingPopulation;
    [Range(0,20)]
    public int MaxFloorCount;
    [Range(0, 20)]
    public int RawCount;
    [Range(0, 20)]
    public int ColumnCount;
    private List<BuildingData> _buildingData;

    private List<Grid> _gridList;

    private void Start()
    {
        _buildingData = new List<BuildingData>();
        _gridList = new List<Grid>();
        
        CityFactory.Init();
        SetupField(RawCount,ColumnCount);
        SetupBuildingsData();
        CityFactory.GenerateCity(_buildingData);
    }

    private void SetupField(int row, int column)
    {
        var gridPosition = Vector3.zero;

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                gridPosition = new Vector3(i, 0, j);
                var grid = new Grid();
                grid.IsFull = false;
                grid.Position = gridPosition;

                _gridList.Add(grid);
            }
        }
    }

	private void SetupBuildingsData()
	{
        for (int i = 0; i < _gridList.Count; i++)
        {
            var desicionFloat = UnityEngine.Random.Range(0f, 100f);
            if (desicionFloat < BuildingPopulation)
            {
                var buildingData = new BuildingData();
                buildingData.Position = _gridList[i].Position;
                buildingData.Type = GetRandomBuildingType();
                buildingData.Grids = new List<Grid>();
                buildingData.Grids.Add(_gridList[i]);
                buildingData.FloorCount = UnityEngine.Random.Range(0, MaxFloorCount);

                _buildingData.Add(buildingData);
            }
        }
    }

    private EBuildingType GetRandomBuildingType()
    {
        EBuildingType[] values = (EBuildingType[])Enum.GetValues(typeof(EBuildingType));
        return values[UnityEngine.Random.Range(0,values.Length)];
    }
}

public struct Grid
{
    public bool IsFull;
    public Vector3 Position;
}
