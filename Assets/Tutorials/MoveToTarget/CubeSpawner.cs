using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {
    public CubesManager CubeManager;
    public CubePool _cubePool;
    public CameraManager _cameraManager;

    public void Init()
    {
        _cameraManager.Init();
        _cubePool.InitCubePool(10);
        StartCoroutine("SpawnCubes");
    }

    private IEnumerator SpawnCubes()
    {
        while (true)
        {
            var wait = new WaitForSeconds(UnityEngine.Random.Range(.1f, .4f));
            var cube = _cubePool.GetMovingCubeFromPool();
            CubeManager.MovingCubes.Add(cube);
            SetCubeStartPosition(cube);
            yield return wait;
        }
    }

    private void SetCubeStartPosition(MovingCube movingCube)
    {
        Vector2 position = CalculateCubeStartPosition();
        movingCube.SetPosition(position);
    }

    private Vector2 CalculateCubeStartPosition()
    {
        var targetEffectSize = 1.5f;
        var signX = GetRandomSign();
        var signY = GetRandomSign();

        var screenMaxPoint = _cameraManager.GetScreenMaxPoint();
        var screenMinPoint = _cameraManager.GetScreenMinPoint();


        Vector2 position = new Vector2(100,100);
        Vector2 targetPosition = CubeManager.Target.position;
        if (signX > 0 && signY > 0)
        {
            position = new Vector2(
                    UnityEngine.Random.Range(-screenMaxPoint.x, screenMaxPoint.x),
                    UnityEngine.Random.Range(targetPosition.y + targetEffectSize, screenMaxPoint.y)
            );
        }
        else if (signX > 0 && signY < 0)
        {
            position = new Vector2(
                    UnityEngine.Random.Range(targetPosition.x + targetEffectSize, screenMaxPoint.x),
                    UnityEngine.Random.Range(-screenMaxPoint.y, screenMaxPoint.y)
            );
        }
        else if (signX < 0 && signY > 0)
        {
            position = new Vector2(
                    UnityEngine.Random.Range(-screenMaxPoint.x, targetPosition.x - targetEffectSize),
                    UnityEngine.Random.Range(-screenMaxPoint.y, screenMaxPoint.y)
            );
        }
        else if (signX < 0 && signY < 0)
        {
            position = new Vector2(
                    UnityEngine.Random.Range(-screenMaxPoint.x, screenMaxPoint.x),
                    UnityEngine.Random.Range(-screenMaxPoint.y, targetPosition.y - targetEffectSize)
            );
        }

        return position;

    }

    private int GetRandomSign()
    {
        var sign = 1;
        var signDesicion = UnityEngine.Random.Range(-20, 20);

        if (signDesicion < 0)
        {
            sign = -1;
        }

        return sign;

    }
}
