using Unity.VisualScripting;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, StateMachine stateMachine) : base(player, stateMachine) {}


    public override void FrameUpdate()
    {
        if (player.GetComponent<PlayerMovement>().MoveDiretion != Vector2.zero)
        {
            stateMachine.ChangeState(player.MovingState);
        }
        Debug.Log("Idling");
    
    }
}
