using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPrefabPool : MonoBehaviour {

    public GameObject NumberPrefab;

    private List<GameObject> _numberPrefabPool;

    public void Init()
    {
        _numberPrefabPool = new List<GameObject>();
    }

    public GameObject GetNumberPrefabFromPool()
    {
        if (_numberPrefabPool.Count == 0)
        {
            _numberPrefabPool.Add(GenerateNumberUI());
        }

        var numberPrefab = _numberPrefabPool[_numberPrefabPool.Count - 1];
        _numberPrefabPool.Remove(numberPrefab);

        numberPrefab.SetActive(true);
        return numberPrefab;
    }

    private GameObject GenerateNumberUI()
    {
        var numberUI = Instantiate(NumberPrefab) as GameObject;
        numberUI.GetComponent<NumberContainer>().Init();
        return numberUI;
    }

    public void AddNumberPrefabToPool(GameObject numberUI)
    {
        numberUI.SetActive(false);
        _numberPrefabPool.Add(numberUI);
    } 
}
