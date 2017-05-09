using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySource : MonoBehaviour {

    public Transform Target;
    private Transform _transform;
    private LayerMask _ignoredLayers;


	void Start ()
    {
        _transform = GetComponent<Transform>();
        _ignoredLayers = ~((1 << LayerMask.NameToLayer("Player")) | (1 << (LayerMask.NameToLayer("Friend"))));
        Shot();
    }

    private void Shot()
    {
        RaycastHit2D hit = Physics2D.Raycast(_transform.position,Target.position, 1000 ,_ignoredLayers);

        if (hit.collider)
        {
            Debug.Log("Target: "+ hit.collider.name + " is shotted!");
        }
    }
}
