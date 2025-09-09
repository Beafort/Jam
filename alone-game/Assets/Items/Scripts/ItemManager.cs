using UnityEngine;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
public class ItemManager : MonoBehaviour
{
    public static int inf_durability = int.MaxValue;
    public static ItemManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    
    [SerializeField] private List<ItemData> allItems = new List<ItemData>();
    public static ItemData placeholderData = null;
    public static ItemInstance placeholderItemInstance = null;

    public Transform itemWorldRender;
    public ItemData GetItemData(ItemData.ID id)
    {
        return allItems[(int)id];
    }

    public ItemInstance CreateItemInstance(ItemData.ID id)
    {
        return new ItemInstance(GetItemData(id));
    }
}
