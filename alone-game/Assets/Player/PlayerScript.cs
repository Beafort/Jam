using System.Collections.Generic;
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

    #region Player Data
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private BarManager healthBar;
    #endregion
    public bool IsMoving { get; set; }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Collision");
        if (collider.CompareTag("droppedItem"))
        {
            ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
            if (itemWorld == null)
            {
                Debug.Log("Item World is null");
                return;
            }

            if (inventory.AddItem(itemWorld.GetItem()) != null) //sucessfully put item in inventory
            {
                itemWorld.DestroySelf();
            }
        }
    }

    public void Awake()
    {
        StateMachine = new StateMachine();

        IdleState = new PlayerIdleState(this, StateMachine);
        MovingState = new PlayerMovingState(this, StateMachine);

        inventory = new Inventory();
        inventoryUI.SetInventory(inventory);
        inventoryUI.SetPlayer(this);
        if (Items.Instance == null) Debug.Log("items inst null");
        if (Items.Instance.GetItem(Item.ID.Healing1) == null) Debug.Log("Null Item");

        healthBar.Init(maxHealth);
    }

    public Vector3 GetPosition()
    {
        if (this != null)
        {
            return this.transform.position;
        }
        else
        {
            return Vector3.zero;
        }
    }
    public float GetHealth() => healthBar.GetBarCurrVal();
    public BarManager Health() => healthBar;
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
 