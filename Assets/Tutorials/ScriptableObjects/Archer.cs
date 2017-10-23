using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour {

    public ArcherData _archerData;

	// Use this for initialization
	void Start ()
    {
        _archerData.Experience = 1200.9f;
        _archerData.KilledBossCount = 56;
        _archerData.SetAge(35);	
	}
}
