using UnityEngine;
using System.Collections;
using System;

public class carController : MonoBehaviour {




	public WheelJoint2D frontwheel;
	public WheelJoint2D backwheel;

	JointMotor2D motorFront;

	JointMotor2D motorBack;

	public float MaxFrontSpeed;
	public float MinBackSpeed;

	public float MaxTorqueFront;
	public float MaxTorqueBack;


	public bool TractionFront = true;
	public bool TractionBack = true;


	public float carRotationSpeed;

    [SerializeField]
    private float _currentSpeed;
	[SerializeField]
    private float _acceleration;
    [SerializeField]
    private float _currentTorque;

    private float _breakForce;

	// Use this for initialization
	void Start () {
        _currentTorque = 0;
        _currentSpeed = 0;
        _acceleration = 100f;
        _breakForce = 200f;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetAxisRaw ("Vertical") > 0) {

            UpdateFrontSpeed();

			if (TractionFront) {
                motorFront.motorSpeed = _currentSpeed * -1;
                motorFront.maxMotorTorque = _currentTorque;
				frontwheel.motor = motorFront;
			}

			if (TractionBack) {
                motorBack.motorSpeed = _currentSpeed * -1;
                motorBack.maxMotorTorque = _currentTorque;
				backwheel.motor = motorBack;

			}

		} else if (Input.GetAxisRaw ("Vertical") < 0) {

            UpdateBackSpeed();

			if (TractionFront) {
                motorFront.motorSpeed = _currentSpeed * -1;
                motorFront.maxMotorTorque = _currentTorque;
				frontwheel.motor = motorFront;
			}

			if (TractionBack) {
                motorBack.motorSpeed = _currentSpeed * -1;
                motorBack.maxMotorTorque = _currentTorque;
				backwheel.motor = motorBack;

			}

		} else {

            _currentTorque = 0;
			backwheel.useMotor = false;
			frontwheel.useMotor = false;

		}

		if (Input.GetAxisRaw ("Horizontal") != 0) {

			GetComponent<Rigidbody2D> ().AddTorque (carRotationSpeed * Input.GetAxisRaw("Horizontal") * -1);

		}

	}

    private void UpdateFrontSpeed()
    {
        _currentSpeed += _acceleration * Time.deltaTime;
        if(_currentSpeed > MaxFrontSpeed)
        {
            _currentSpeed = MaxFrontSpeed;
        }

        _currentTorque += 100 * Time.deltaTime;
        if(_currentTorque > MaxTorqueFront)
        {
            _currentTorque = MaxTorqueFront;
        }
    }

    private void UpdateBackSpeed()
    {
        _currentSpeed -= _breakForce * Time.deltaTime;
        if(_currentSpeed < MinBackSpeed)
        {
            _currentSpeed = MinBackSpeed;
        }

        _currentTorque += 100 * Time.deltaTime;
        if (_currentTorque > MaxTorqueBack)
        {
            _currentTorque = MaxTorqueBack;
        }

    }
}
