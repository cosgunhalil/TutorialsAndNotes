using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFactory : MonoBehaviour {

    public static BuildingFactory Instance;

    public List<GameObject> BuildingPrefabs;

    private Dictionary<EBuildingType, GameObject> _buildingDictionary;

    public void Init()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        InitBuildingDictionary();
    }

    private void InitBuildingDictionary()
    {
		_buildingDictionary = new Dictionary<EBuildingType, GameObject>();


		var buildingTypeNames = Enum.GetNames(typeof(EBuildingType));

		for (int i = 0; i < buildingTypeNames.Length; i++)
		{
			var type = (EBuildingType)Enum.Parse(typeof(EBuildingType), buildingTypeNames[i]);
			_buildingDictionary.Add(type, BuildingPrefabs[i]);
		}
    }

    public IBuilding GenerateBuilding(EBuildingType type, int floorCount)
    {
        var building = Instantiate(_buildingDictionary[type]) as GameObject;
        var buildingModel = building.GetComponent<IBuilding>();

        buildingModel.Init();
        buildingModel.BuildingType = type;
        buildingModel.FloorCount = floorCount;

        return buildingModel;

    }


}
