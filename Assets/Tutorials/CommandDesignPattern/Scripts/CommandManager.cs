using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour {

    public InputHandler InputManager;

    public Soldier CurrentSelectedSoldierObject;

    public TroopManager _troopManager;

    public Command _moveForwardCommand;
	public Command _moveBackwardCommand;
	public Command _moveLeftCommand;
	public Command _moveRightCommand;
	public Command _undoCommand;

    private Dictionary<Soldier, List<Command>> _commandDictionary = new Dictionary<Soldier, List<Command>>();

	private Vector3 _objectStartPos;

    private Soldier _prevSelectedSoldierObject;

	void Start () 
    {
        InputManager.Init(this);

        _moveForwardCommand = new MoveForward();
        _moveForwardCommand.Init(this);

		_moveBackwardCommand = new MoveBackward();
        _moveBackwardCommand.Init(this);

		_moveLeftCommand = new MoveLeft();
        _moveLeftCommand.Init(this);

		_moveRightCommand = new MoveRight();
        _moveRightCommand.Init(this);

		_undoCommand = new Undo();
        _undoCommand.Init(this);

        _troopManager.Init();

	}

    void Update()
    {
        InputManager.HandleInput();
    }

    public void SetSelectedSoldier(Soldier soldier)
    {
        if (CurrentSelectedSoldierObject == null)
        {
            CurrentSelectedSoldierObject = soldier;
        }
        else
        {
            _prevSelectedSoldierObject = CurrentSelectedSoldierObject;
            CurrentSelectedSoldierObject = soldier;
        }

        if (_prevSelectedSoldierObject != null) 
        {
            _prevSelectedSoldierObject.DeSelect();
        }

        if (_commandDictionary.ContainsKey(CurrentSelectedSoldierObject) == false)
        {
            CreateCommanContainer();
        }

        CurrentSelectedSoldierObject.Select(Color.green);
    }

    public List<Command> GetCommandContainer()
    {
        var commandContainer = _commandDictionary[CurrentSelectedSoldierObject];
        return commandContainer;
    }

    public void AddCommandToContainer(Command command)
    {
		var commandContainer = new List<Command>();

        if (_commandDictionary.ContainsKey(CurrentSelectedSoldierObject) == false)
        {
            CreateCommanContainer();
        }

        commandContainer = _commandDictionary[CurrentSelectedSoldierObject];
		commandContainer.Add(command);
    }

    public void CreateCommanContainer()
    {
        var commandContainer = new List<Command>();
        _commandDictionary.Add(CurrentSelectedSoldierObject, commandContainer);
    }

}
