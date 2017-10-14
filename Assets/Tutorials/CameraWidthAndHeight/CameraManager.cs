using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    public Camera MainCamera;

    [SerializeField]
    private float _height;
    [SerializeField]
    private float _width;
    [SerializeField]
    private Vector2 _screenMaxPoint;
    [SerializeField]
    private Vector2 _screenMinPoint;


	public void Init ()
    {
        _height = 2f * MainCamera.orthographicSize;
        _width = _height * MainCamera.aspect;

        _screenMaxPoint = new Vector2(_height / 2f, _width / 2f);
        _screenMinPoint = new Vector2(-_height / 2f, -_width / 2f);

    }

    public Vector2 GetScreenMaxPoint()
    {
        return _screenMaxPoint;
    }

    public Vector2 GetScreenMinPoint()
    {
        return _screenMinPoint;
    }
}
