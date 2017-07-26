using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour {

    public static CommandManager Instance;

    public InputHandler InputManager;

	public Soldier SoldierObject;

    public Command _moveForwardCommand;
	public Command _moveBackwardCommand;
	public Command _moveLeftCommand;
	public Command _moveRightCommand;
	public Command _undoCommand;
	public Command _replayCommand;

	public List<Command> PrevCommands = new List<Command>();

	private Vector3 _objectStartPos;

	private Coroutine _replayCoroutine;

	public bool shouldStartReplay;


	// Use this for initialization
	void Start () 
    {
        if (Instance == null)
        {
            Instance = this;
        }

        SoldierObject.Init();
        InputManager.Init(this);

		_moveForwardCommand = new MoveForward();
		_moveBackwardCommand = new MoveBackward();
		_moveLeftCommand = new MoveLeft();
		_moveRightCommand = new MoveRight();
		_undoCommand = new Undo();
		_replayCommand = new Replay();

		_objectStartPos = SoldierObject.GetStartPosition();
	}

    void Update()
    {
        InputManager.HandleInput();
    }

    public void StartReplay()
	{
		if (shouldStartReplay && PrevCommands.Count > 0)
		{
			shouldStartReplay = false;

			if (_replayCoroutine != null)
			{
				StopCoroutine(_replayCoroutine);
			}

			_replayCoroutine = StartCoroutine(ReplayCommands(SoldierObject.GetTransform()));
		}
	}

	IEnumerator ReplayCommands(Transform objectTransform)
	{
		InputManager._isReplay = true;

		objectTransform.position = _objectStartPos;

		for (int i = 0; i < PrevCommands.Count; i++)
		{
			PrevCommands[i].Move(objectTransform);

			yield return new WaitForSeconds(0.3f);
		}

		InputManager._isReplay = false;
	}


}
