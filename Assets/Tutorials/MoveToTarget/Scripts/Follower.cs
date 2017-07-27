using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {

    private float _speed;
    private Transform _transform;

    public void Init()
    {
        _speed = 2f;
        _transform = GetComponent<Transform>();
    }

    public void Move(Transform target)
    {
        float distance = Vector3.Distance(target.position, transform.position);

		if (distance > 1.0f)
		{
            Vector3 dir = target.position - transform.position;
			dir.Normalize();                                    
            transform.position += dir * _speed * Time.deltaTime; 
		}
	}

}
