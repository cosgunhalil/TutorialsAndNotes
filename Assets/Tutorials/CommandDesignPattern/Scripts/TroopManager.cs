using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopManager : MonoBehaviour {

    public GameObject SoldierPrefab;
    public List<Troop> TroopList;

    private Stack<Soldier> _soldierPool;

    private int _soldierInTroopCount = 9;

	public void Init()
	{
		_soldierPool = new Stack<Soldier>();
		SetupTroops(3);
	}

    private void SetupTroops(int troopCount)
    {
        for (int i = 0; i < troopCount; i++)
        {
            Troop troop = new Troop();
            troop.Init(this);
            troop.TroopIndex = i;

            for (int j = 0; j < _soldierInTroopCount; j++)
            {
                GenerateSoldier(troop);
            }

			PlaceSoldiers(troop);
        }
    }

    private void GenerateSoldier(Troop ownerTroop)
    {
        var soldier = GetSoldierFromPool();
        soldier.Init(ownerTroop);

        ownerTroop.SoldiersInTheTroop.Add(soldier);
    }

    private Soldier GetSoldierFromPool()
    {
        if (_soldierPool.Count == 0)
        {
            var soldier = Instantiate(SoldierPrefab) as GameObject;
            var soldierView = soldier.GetComponent<Soldier>();
            _soldierPool.Push(soldierView);
        }

        var soldierToPush = _soldierPool.Pop();

        return soldierToPush;
    }

    public void SetSoldierToPool(Soldier soldier)
    {
        _soldierPool.Push(soldier);
    }

    private void PlaceSoldiers(Troop troop)
	{
        var soldierCount = troop.SoldiersInTheTroop.Count;
        var soldierPositions = GetSoldierPositions(troop); 

        for (int i = 0; i < soldierCount; i++)
        {
            troop.SoldiersInTheTroop[i].SetPosition(soldierPositions[i]);
        }
    }

    private List<Vector3> GetSoldierPositions(Troop troop)
    {
        var soldierCount = troop.SoldiersInTheTroop.Count;
        List<Vector3> soldierPositions = new List<Vector3>();

        var soldierCountInARow = (int)Mathf.Sqrt(soldierCount);

        var distanceBetweenTroops = 3f;

        for (int i = 0; i < soldierCountInARow; i++)
        {
            for (int j = 0; j < soldierCountInARow; j++)
            {
                var soldierPosition = new Vector3(
                    i + (troop.TroopIndex * distanceBetweenTroops), 
                    0, 
                    j + (troop.TroopIndex * distanceBetweenTroops)
                );

                soldierPositions.Add(soldierPosition);
            }
        }

        return soldierPositions;
    }
}

public struct Troop
{
    public TroopManager OwnerTroopManager;
    public List<Soldier> SoldiersInTheTroop;
    public EFormation Formation;
    public int TroopIndex;

    public void Init(TroopManager manager)
    {
        Formation = EFormation.square;
        OwnerTroopManager = manager;
        SoldiersInTheTroop = new List<Soldier>();
    }
}

public enum EFormation
{
    square
}
