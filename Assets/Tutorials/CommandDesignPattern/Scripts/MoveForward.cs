using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : Command {

	public override void Init(CommandManager manager)
	{
        _commandManager = manager;
	}

    public override void Execute(Soldier objectTransform, Command command)
	{
        Move(objectTransform.GetTransform());

        _commandManager.AddCommandToContainer(command);
	}

	public override void Undo(Transform objectTransform)
	{
		objectTransform.Translate(-objectTransform.forward * MoveDistance);
	}

	public override void Move(Transform objectTransform)
	{
		objectTransform.Translate(objectTransform.forward * MoveDistance);
	}

}
