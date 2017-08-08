using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringConcatenatePerformance : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        var startTime = System.DateTime.Now;
        ConcatenateStrings();
        var endTime = System.DateTime.Now;

        Debug.Log("Start Time = " + startTime);
        Debug.Log("End Time = " + endTime);
        Debug.Log("Concatenate Time = " + (endTime - startTime));
	}

    private void ConcatenateStrings()
    {
        string s = "Conrate";
        string concatenatedString = String.Empty;
        int steps = 30000;
        
        for (int i = 0; i < steps; i++)
        {
            //concatenatedString = string.Concat(concatenatedString,s);
            concatenatedString += s;
        }
    }
}
