using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform _transform;
    private float _speed;

    public void Init()
    {
        _transform = GetComponent<Transform>();
        _speed = 10f;
    }

    public void Move()
    {
        _transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    public Vector3 GetPosition()
    {
        return _transform.position;
    }

    public void SetPosition(Vector3 position)
    {
        _transform.position = position;
    }
}
