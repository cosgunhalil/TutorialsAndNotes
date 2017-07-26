using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : Command {

	//Called when we press a key
    public override void Execute(Soldier objectTransform, Command command)
	{
		//Move the box
        Move(objectTransform.GetTransform());

		//Save the command
        CommandManager.Instance.PrevCommands.Add(command);
	}

	//Undo an old command
	public override void Undo(Transform objectTransform)
	{
        objectTransform.Translate(objectTransform.right * MoveDistance);
	}

	//Move the box
	public override void Move(Transform objectTransform)
	{
        objectTransform.Translate(-objectTransform.right * MoveDistance);
	}
}
