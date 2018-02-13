using System.Collections;
using UnityEngine;

public class CounterManager : MonoBehaviour {
    private Transform _transform;
    private int _blueCount;
    private int _redCount;

    void Start()
    {
        _transform = GetComponent<Transform>();
        StartCoroutine(BlueCounter());
        StartCoroutine("RedCounter");
    }

    private IEnumerator BlueCounter()
    {
        var wait = new WaitForSeconds(1f);
        _blueCount = 0;

        while (true)
        {
            yield return wait;
            _blueCount++;
            Debug.Log("<color=blue>Blue Count: </color>" + _blueCount);
        }
    }

    private IEnumerator RedCounter()
    {
        _redCount = 0;
        var wait = new WaitForSeconds(1f);
        while (true)
        {
            yield return wait;
            _redCount++;
            Debug.Log("<color=red>Red Count: </color>" + _redCount);
        }
    }

    private void OnGUI()
    {
        //can not be stopped
        if (GUILayout.Button("STOP BLUE COUNTER"))
        {
            StopCoroutine("BlueCounter");
        }

        //can be stopped
        if (GUILayout.Button("STOP RED COUNTER"))
        {
            StopCoroutine("RedCounter");
        }
    }
}
