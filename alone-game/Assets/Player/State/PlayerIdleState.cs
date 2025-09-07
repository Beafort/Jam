using Unity.VisualScripting;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, StateMachine stateMachine) : base(player, stateMachine) {}

    public override void EnterState()
    {
        
    }
    public override void FrameUpdate()
    {
        if (player.GetComponent<PlayerMovement>().MoveDirection != Vector2.zero)
        {
            stateMachine.ChangeState(player.MovingState);
        }
        Debug.Log("Idling");
    
    }
}
