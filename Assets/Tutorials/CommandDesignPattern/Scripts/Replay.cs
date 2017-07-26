using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replay : Command {

    public override void Execute(Soldier objectTransform, Command command)
	{
        CommandManager.Instance.shouldStartReplay = true;
	}
}
