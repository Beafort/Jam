using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovingState : PlayerState
{
    public PlayerMovingState(Player player, StateMachine stateMachine) : base(player, stateMachine) {}

    public override void FrameUpdate()
    {
        if (player.GetComponent<PlayerMovement>().MoveDiretion == Vector2.zero)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }
}
