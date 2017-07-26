using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Undo : Command {

	//Called when we press a key
    public override void Execute(Soldier objectTransform, Command command)
	{
        List<Command> prevCommands = CommandManager.Instance.PrevCommands;

		if (prevCommands.Count > 0)
		{
			Command latestCommand = prevCommands[prevCommands.Count - 1];

			//Move the box with this command
            latestCommand.Undo(objectTransform.GetTransform());

			//Remove the command from the list
			prevCommands.RemoveAt(prevCommands.Count - 1);
		}
	}

}
