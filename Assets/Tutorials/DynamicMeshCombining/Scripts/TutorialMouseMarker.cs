using UnityEngine;
using System.Collections;

//http://www.habrador.com/tutorials/unity-mesh-combining-tutorial/2-basic-scene/

//Creates a cities skylines style round circle that 
//will move around with the mouse and is resizable
public class TutorialMouseMarker : MonoBehaviour
{
	public static TutorialMouseMarker current;

	//Drags
	//The gameobject holding the projector
	public GameObject circleObj;
	//The projector that will display the circle
	public Projector projector;

	//Projector settings
	float projectorMax = 15f;
	float projectorMin = 3f;

	void Awake()
	{
		current = this;
	}

	void Update()
	{
		UpdateProjector();
	}

	//Move the circle and change its size
	void UpdateProjector()
	{
		//Find the position of the mouse
		Vector3 mouseScreenPosition = Input.mousePosition;

		RaycastHit hit;

		//Fire ray and make sure we hit ground which is layer 10
		if (Physics.Raycast(Camera.main.ScreenPointToRay(mouseScreenPosition), out hit, 1000f, 1 << 18))
		{
			//Change the position of the circle to the position
			//where the ray hit the ground
			circleObj.transform.position = hit.point;
		}

		//Change size of projector radius
		float projectorSize = projector.orthographicSize;

		//Increase/decrease with p and m keys
		if (Input.GetKey(KeyCode.P))
		{
			projectorSize += 0.5f;
		}
		else if (Input.GetKey(KeyCode.M))
		{
			projectorSize -= 0.5f;
		}

		//Make sure it can't grow too big nor too small
		projector.orthographicSize = Mathf.Clamp(projectorSize, projectorMin, projectorMax);
	}
}