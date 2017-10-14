using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour {

    public GameObject MovingCubePrefab;

    [SerializeField]
    private Stack<MovingCube> _readyToUseCubes;

    public void InitCubePool(int poolPopulationStartCount)
    {
        _readyToUseCubes = new Stack<MovingCube>();
        GenerateCube(poolPopulationStartCount);
    }

    private void GenerateCube(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var cube = Instantiate(MovingCubePrefab).GetComponent<MovingCube>();
            cube.Init();
            cube.gameObject.SetActive(false);
            _readyToUseCubes.Push(cube);
        }
    }

    public MovingCube GetMovingCubeFromPool()
    {
        if (_readyToUseCubes.Count == 0)
        {
            GenerateCube(1);
        }

        var movingCube = _readyToUseCubes.Pop();

        movingCube.Init();

        return movingCube;
    }

    public void AddMovingCubeToPool(MovingCube cube)
    {
        _readyToUseCubes.Push(cube);
        cube.gameObject.SetActive(false);
    }


}
