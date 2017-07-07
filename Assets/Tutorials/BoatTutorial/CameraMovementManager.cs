using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementManager : MonoBehaviour {

    public float CameraSensitivity = 90;
    public float ClimbSpeed = 4;
    public float NormalMoveSpeed = 10;
    public float SlowMoveFactor = 0.25f;
    public float FastMoveFactor = 3;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    private Transform _transform;


    void Start()
    {
        _transform = GetComponent<Transform>();
        Screen.lockCursor = true;
    }

    void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * CameraSensitivity * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse Y") * CameraSensitivity * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, -90, 90);

        _transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        _transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            _transform.position += transform.forward * (NormalMoveSpeed * FastMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
            _transform.position += transform.right * (NormalMoveSpeed * FastMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            _transform.position += _transform.forward * (NormalMoveSpeed * SlowMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
            _transform.position += _transform.right * (NormalMoveSpeed * SlowMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
        }
        else
        {
            _transform.position += _transform.forward * NormalMoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            _transform.position += _transform.right * NormalMoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.Q)) { _transform.position += _transform.up * ClimbSpeed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.E)) { _transform.position -= _transform.up * ClimbSpeed * Time.deltaTime; }

        if (Input.GetKeyDown(KeyCode.End))
        {
            Screen.lockCursor = (Screen.lockCursor == false) ? true : false;
        }
    }
}
