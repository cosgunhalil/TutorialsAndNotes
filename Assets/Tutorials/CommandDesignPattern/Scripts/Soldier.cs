using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{

    private Transform _transform;
    private Vector3 _startPosition;
    private Troop _ownerTroop;
    private Material _material;
    private Color _normalColor;
    private Vector3 _size;

    public void Init(Troop ownerTroop)
    {
        _ownerTroop = ownerTroop;
		_transform = GetComponent<Transform>();
        _material = GetComponent<Renderer>().material;
        _normalColor = _material.color;
		_startPosition = _transform.position;
		_size = _transform.localScale;
    }

    public Transform GetTransform()
    {
        return _transform;
    }

    public Vector3 GetStartPosition()
    {
        return _startPosition;
    }

    public Vector3 GetSize()
    {
        return _size;
    }

    public void SetPosition(Vector3 position)
    {
        _transform.position = position;
    }

    public void Death()
    {
		gameObject.SetActive(false);
        _ownerTroop.SoldiersInTheTroop.Remove(this);
        _ownerTroop.OwnerTroopManager.SetSoldierToPool(this);
    }

    public void Select(Color color)
    {
        _material.color = color;
    }

    public void DeSelect()
    {
        _material.color = _normalColor;
    }
}
