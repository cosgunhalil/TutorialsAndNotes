using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour {

    private float _speed;
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;

    private float _maxSpeed = 2f;
    private float _minSpeed = 1f;

    private bool _isReachedToTarget;

    public void Init()
    {
        if (_transform == null)
        {
            _transform = GetComponent<Transform>();
        }

        if (_spriteRenderer == null)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        _isReachedToTarget = false;
        gameObject.SetActive(true);
        SetRandomSpeed();
        SetRandomColor();
    }

    public void SetRandomSpeed()
    {
        _speed = UnityEngine.Random.Range(_minSpeed , _maxSpeed);
    }

    private void SetRandomColor()
    {
        var color = new Color32(
                (byte)UnityEngine.Random.Range(0, 255),
                (byte)UnityEngine.Random.Range(0, 255),
                (byte)UnityEngine.Random.Range(0, 255),
                255
            );

        _spriteRenderer.color = color;
    }

    public void SetPosition(Vector2 position)
    {
        _transform.position = position;
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
        else
        {
            OnTargetReached();
        }
	}

    private void OnTargetReached()
    {
        gameObject.SetActive(false);
        _isReachedToTarget = true;
    }

    public bool IsReachedToTarget()
    {
        return _isReachedToTarget;
    }
}
