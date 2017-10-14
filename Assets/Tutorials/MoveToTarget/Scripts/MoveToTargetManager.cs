using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetManager : MonoBehaviour {

    public List<Follower> Followers;
    public Transform Target;

    void Start()
    {
        InitFollowers();
    }

    private void InitFollowers()
    {
        foreach (var follower in Followers)
        {
            follower.Init();
        }
    }

    void Update()
    {
        foreach (var follower in Followers)
        {
            follower.Move(Target);
        }
    }
}
