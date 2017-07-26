using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopManager : MonoBehaviour {

    public List<Troop> TroopList;
    public InputHandler InputManager;

    private Troop _currentSelectedTroop;
    private Troop _prevSelectedTroop;

    public void Start()
    {
        SetupTroops();
    }

    private void SetupTroops()
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        
    }

}
