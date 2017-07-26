using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuilding {

    int FloorCount
    {
        get;
        set;
    }

    float FloorHeight
    {
        get;
        set;
    }

    EBuildingType BuildingType
    {
        get;
        set;
    }

    void Init();
    void Place(Vector3 position, List<Grid> gridList);
    void SetFloorCount(int floorCount);

}

public enum EBuildingType
{
    GreenBuilding,
    RedBuilding,
    BlueBuilding
}
