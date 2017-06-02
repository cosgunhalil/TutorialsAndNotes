using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]
    private float _lenght;
    [SerializeField]
    private float _height;
    [SerializeField]
    private float _width;
    [SerializeField]
    private float _mass;

    private Transform _transform;
    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;


    public void Init()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = gameObject.AddComponent<Rigidbody>();
        _boxCollider = gameObject.AddComponent<BoxCollider>();
    }

    public void SetSizes(float width, float height, float lenght)
    {
        _width = width;
        _height = height;
        _lenght = lenght;

        _mass = _lenght * _height * _width;

        _rigidbody.mass = _mass;

        _boxCollider.size = new Vector3(lenght, width, height);
    }

    public float GetHeight()
    {
        return _height;
    }

    public float GetLenght()
    {
        return _lenght;
    }

    public float GetWidth()
    {
        return _width;
    }

    public void SetPosition(Vector3 pos)
    {
        _transform.position = pos;
    }

    public Transform GetTransform()
    {
        return _transform;
    }

    public float GetMass()
    {
        return _mass;
    }
} 
