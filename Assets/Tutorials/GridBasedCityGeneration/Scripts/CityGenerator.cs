using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour {

    public BuildingFactory BuildingGenerator;

    public void Init()
    {
        BuildingGenerator.Init();
    }

    public void GenerateCity(List<BuildingData> buildingDataList)
    {
        foreach (var buildingData in buildingDataList)
        {
            var building = BuildingGenerator.GenerateBuilding(buildingData.Type, buildingData.FloorCount);
            building.Place(buildingData.Position, buildingData.Grids);
        }
    }

    public void GenerateCity(List<Vector3> positionList)
    {
        
    }

}

public struct BuildingData
{
    public int FloorCount;
    public EBuildingType Type;
    public Vector3 Position;
    public List<Grid> Grids;
}
