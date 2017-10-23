using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ArcherData : ScriptableObject {

    public float Experience;
    public float KilledBossCount;
    [SerializeField]
    private int _age;

    public void SetAge(int age)
    {
        _age = age;
    }

    public int GetAge()
    {
        return _age;
    }
}
