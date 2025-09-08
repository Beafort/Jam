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

    #region Inventory
    //handles player inventory, health, and stuff. 
    private Inventory inventory;
    [SerializeField] private uiInventory inventoryUI;
    #endregion

    public bool IsMoving { get; set; }
    
    public void Awake()
    {
        StateMachine = new StateMachine();

        IdleState = new PlayerIdleState(this, StateMachine);
        MovingState = new PlayerMovingState(this, StateMachine);

        inventory = new Inventory();
        inventoryUI.SetInventory(inventory);
        ItemWorld.SpawnItemWorld(new Vector3(1, 1), Items.Instance.GetItem(Item.Type.Healing1));
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
 