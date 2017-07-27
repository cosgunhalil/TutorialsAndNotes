using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command {

	public CommandManager _commandManager;
    public float MoveDistance = 2f;

    public abstract void Init(CommandManager manager);
    public abstract void Execute(Soldier objectTransform, Command command);

    public virtual void Undo(Transform objectTransform)
    {
        
    }

    public virtual void Move(Transform objectTransform)
    {
        
    }
	
}
