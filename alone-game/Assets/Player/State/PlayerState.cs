using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class PlayerState
{
    protected Player player;
    protected StateMachine stateMachine;
    public PlayerState(Player player, StateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }
    public virtual void EnterState() { }
    public virtual void EnterState(object data) => EnterState();
    public virtual void ExitState() { }

    public virtual void FrameUpdate() { }
    public virtual void PhysicsUpdate() { }

}
