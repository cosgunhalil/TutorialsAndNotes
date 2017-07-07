using System;
using UnityEngine;

public class MathOperation : MonoBehaviour {

    public Transform Follower;
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        Follower.position = RoundCoordinates(mousePosition);
    }

    public Vector3 RoundCoordinates(Vector3 position)
    {
        var roundedPosition = new Vector3(
                (float)Math.Round(position.x, 1),
                (float)Math.Round(position.y , 1),
                0
            );

        return roundedPosition;
    }
}
