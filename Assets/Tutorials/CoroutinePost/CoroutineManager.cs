using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour {
    private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
        StartCoroutine(Move(new Vector3(10, 10, 0), new Vector3(-10, -7, 0)));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StopCoroutine("Move");
        }
    }

    private IEnumerator Move(Vector3 startPosition, Vector3 targetPosition)
    {
        _transform.position = startPosition;
        while (true)
        {
            float speed = 1f * Time.deltaTime;
            _transform.Translate((targetPosition - startPosition) * speed);

            yield return new WaitForEndOfFrame();
        }
    }
}
