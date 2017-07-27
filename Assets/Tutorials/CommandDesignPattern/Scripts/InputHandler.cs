using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//http://gameprogrammingpatterns.com/
//http://www.habrador.com/tutorials/programming-patterns/1-command-pattern/

public class InputHandler : MonoBehaviour {

    public LayerMask AllowedLayer;

	private CommandManager _commandManager;
    private Camera _mainCamera;
    private Transform _mainCameraTransform;

    public void Init(CommandManager commandManager)
    {
        _commandManager = commandManager;
        _mainCamera = Camera.main;
        _mainCameraTransform = Camera.main.transform;
    }

	void InputHandlerUpdate()
	{
		HandleInput();
	}

	public void HandleInput()
	{
        if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
            _commandManager._moveLeftCommand.Execute(_commandManager.CurrentSelectedSoldierObject, _commandManager._moveLeftCommand);
		}
        else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
            _commandManager._moveRightCommand.Execute(_commandManager.CurrentSelectedSoldierObject, _commandManager._moveRightCommand);
		}
        else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			_commandManager._moveForwardCommand.Execute(_commandManager.CurrentSelectedSoldierObject, _commandManager._moveForwardCommand);
		}
        else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			_commandManager._moveBackwardCommand.Execute(_commandManager.CurrentSelectedSoldierObject, _commandManager._moveBackwardCommand);
		}
        else if (Input.GetKeyDown(KeyCode.U))
		{
            _commandManager._undoCommand.Execute(_commandManager.CurrentSelectedSoldierObject, _commandManager._undoCommand);
		}

        if (Input.GetMouseButtonDown(0))
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

			RaycastHit hit;

            if (Physics.Raycast(ray, out hit, float.MaxValue,AllowedLayer))
			{
                var soldier = hit.collider.GetComponent<Soldier>();
                _commandManager.SetSelectedSoldier(soldier);
            }
        }

       
    }
}

