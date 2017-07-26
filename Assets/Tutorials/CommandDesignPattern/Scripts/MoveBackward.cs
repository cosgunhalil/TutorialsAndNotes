using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackward : Command
{
    public override void Execute(Soldier objectTransform, Command command)
	{
        Move(objectTransform.GetTransform());

        CommandManager.Instance.PrevCommands.Add(command);
	}

	public override void Undo(Transform objectTransform)
	{
        objectTransform.Translate(objectTransform.forward * MoveDistance);
	}

	public override void Move(Transform objectTransform)
	{
        objectTransform.Translate(-objectTransform.forward * MoveDistance);
	}
}
