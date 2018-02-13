using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour {

    public ArcherData _archerData;

	void Start ()
    {
        Debug.Log(_archerData.Power);
        Debug.Log(_archerData.Health);
	}
}
