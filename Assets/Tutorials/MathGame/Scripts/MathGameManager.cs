using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathGameManager : MonoBehaviour {

    public NumberPrefabPool NumberPool;
    public Transform NumberContainerTransform;

    private OperationGenerator _operationGenerator;
    private List<Operation> _levels;
	// Use this for initialization
	void Start () 
    {
        _operationGenerator = new OperationGenerator();
        _levels = new List<Operation>();

        NumberPool.Init();

        InitLevels();
        SetupLevel(0);
	}

    private void InitLevels()
	{
        var levelCount = 1;

        for (int i = 0; i < levelCount; i++)
        {
            _levels.Add(_operationGenerator.GetOperation());
        }
    }

	private void SetupLevel(int level)
	{
        foreach (var val in _levels[level].Numbers)
        {
            var number = NumberPool.GetNumberPrefabFromPool();
            number.GetComponent<NumberContainer>().Value = val;
            number.transform.parent = NumberContainerTransform;
        }
    }
}
