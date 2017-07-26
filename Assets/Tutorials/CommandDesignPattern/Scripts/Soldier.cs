using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{

    private Transform _transform;
    private Vector3 _startPosition;
    private Troop _ownerTroop;

    public void Init()
    {
        _transform = GetComponent<Transform>();
        _startPosition = _transform.position;
    }

    public void Init(Troop ownerTroop)
    {
        _ownerTroop = ownerTroop;
    }

    public Transform GetTransform()
    {
        return _transform;
    }

    public Vector3 GetStartPosition()
    {
        return _startPosition;
    }

    public void Death()
    {
        _ownerTroop.SoldiersInTroop.Remove(this);
        //TODO send to soldier pool
        gameObject.SetActive(false);
    }
}
