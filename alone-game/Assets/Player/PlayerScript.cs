using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Player: MonoBehaviour
{
    
    #region State Machine
    //State machine and all existing state is init here
    public StateMachine StateMachine { get; set; }
    public PlayerIdleState IdleState { get; set; }    
    public PlayerMovingState MovingState { get; set; }
    #endregion
    public void Awake()
    {
        StateMachine = new StateMachine();

        IdleState = new PlayerIdleState(this, StateMachine);
        MovingState = new PlayerMovingState(this, StateMachine);
    }

    void Start()
    {
        StateMachine.Init(IdleState);
    }
    void Update()
    {
        StateMachine.CurrentPlayerState?.FrameUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentPlayerState?.PhysicsUpdate();
    }
}
 