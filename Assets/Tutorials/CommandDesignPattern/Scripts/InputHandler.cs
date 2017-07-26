using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//http://gameprogrammingpatterns.com/
//http://www.habrador.com/tutorials/programming-patterns/1-command-pattern/

public class InputHandler : MonoBehaviour {

    private CommandManager _commandManager;
    public bool _isReplay;

    public void Init(CommandManager commandManager)
    {
        _commandManager = commandManager;
    }

	void InputHandlerUpdate()
	{
		if (!_isReplay)
		{
			HandleInput();
		}

        _commandManager.StartReplay();
	}

	public void HandleInput()
	{
        if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
            _commandManager._moveLeftCommand.Execute(_commandManager.SoldierObject, _commandManager._moveLeftCommand);
		}
        else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
            _commandManager._moveRightCommand.Execute(_commandManager.SoldierObject, _commandManager._moveRightCommand);
		}
        else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			_commandManager._moveForwardCommand.Execute(_commandManager.SoldierObject, _commandManager._moveForwardCommand);
		}
        else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			_commandManager._moveBackwardCommand.Execute(_commandManager.SoldierObject, _commandManager._moveBackwardCommand);
		}
        else if (Input.GetKeyDown(KeyCode.R))
		{
            _commandManager._replayCommand.Execute(_commandManager.SoldierObject, _commandManager._replayCommand);
		}
        else if (Input.GetKeyDown(KeyCode.U))
		{
            _commandManager._undoCommand.Execute(_commandManager.SoldierObject, _commandManager._undoCommand);
		}
	}
}

