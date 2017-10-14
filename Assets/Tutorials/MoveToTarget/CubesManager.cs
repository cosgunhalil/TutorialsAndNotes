using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesManager : MonoBehaviour {

    public List<MovingCube> MovingCubes;
    public Transform Target;
    public CubeSpawner _cubeSpawner;
    public CubePool _cubePool;

    void Start()
    {
        _cubeSpawner.Init();
    }

    void Update()
    {
        for (int i = 0; i < MovingCubes.Count; i++)
        {
            MovingCubes[i].Move(Target);

            if (MovingCubes[i].IsReachedToTarget())
            {
                RemoveCubeFromMovingCubesList(MovingCubes[i]);
            }

        }
    }

    public void RemoveCubeFromMovingCubesList(MovingCube cube)
    {
        if (MovingCubes.Contains(cube))
        {
            MovingCubes.Remove(cube);
            _cubePool.AddMovingCubeToPool(cube);
        }
    }

    
}
