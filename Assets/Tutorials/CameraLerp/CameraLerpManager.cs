﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerpManager : MonoBehaviour {
    
    public Transform Target;
    private Transform _transform;

	void Start () 
    {
        _transform = GetComponent<Transform>();	
	}

    private void FixedUpdate()
    {
		if (Target != null)
		{
			_transform.position = new Vector3(

			  Mathf.Lerp(_transform.position.x, Target.position.x + 5f, 3.0f * Time.deltaTime),
			  Mathf.Lerp(_transform.position.y, Target.position.y, 3.0f * Time.deltaTime),
			  _transform.position.z

		   );

		}
    }

    public void SetTarget(Transform target)
    {
        Target = target;
    }
}
