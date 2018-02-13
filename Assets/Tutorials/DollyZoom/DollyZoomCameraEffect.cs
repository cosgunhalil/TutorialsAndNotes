using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollyZoomCameraEffect : MonoBehaviour {

    public Transform target;
    public Camera camera;

    private float _initHeightAtDist;
    private bool _dollyZoomEnabled;

    private float FrustumHeightAtDistance(float distance)
    {
        return 2.0f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
    }

    private float FOVForHeightAndDistance(float height, float distance)
    {
        return 2.0f * Mathf.Atan(height * 0.5f / distance) * Mathf.Rad2Deg;
    }
     
    void StartDollyZoomEffect()
    {
        var distance = Vector3.Distance(transform.position, target.position);
        _initHeightAtDist = FrustumHeightAtDistance(distance);
        _dollyZoomEnabled = true;
    }

    void StopDollyZoomEffect()
    {
        _dollyZoomEnabled = false;
    }

    void Start()
    {
        StartDollyZoomEffect();
    }

    void Update()
    {
        if (_dollyZoomEnabled)
        {
            var currDistance = Vector3.Distance(transform.position, target.position);
            camera.fieldOfView = FOVForHeightAndDistance(_initHeightAtDist, currDistance);
        }

        transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * 5f);
    }
}
