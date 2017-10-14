using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Undo : Command {

	public override void Init(CommandManager manager)
	{
        _commandManager = manager;
	}

    public override void Execute(Soldier objectTransform, Command command)
	{

        List<Command> prevCommands = _commandManager.GetCommandContainer();

        if (prevCommands.Count > 0 && prevCommands != null)
		{
			Command latestCommand = prevCommands[prevCommands.Count - 1];

            latestCommand.Undo(objectTransform.GetTransform());

			prevCommands.RemoveAt(prevCommands.Count - 1);
		}

	}


}
