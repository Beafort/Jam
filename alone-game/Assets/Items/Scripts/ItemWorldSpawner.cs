using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ItemData itemData;

    private void Awake()
    {
        if (itemData == null) Debug.Log("Item null");
        ItemWorld.SpawnItemWorld(transform.position, new ItemInstance(itemData));
        Destroy(gameObject);
    }
}
