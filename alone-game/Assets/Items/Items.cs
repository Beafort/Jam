using UnityEngine;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
public class Items : MonoBehaviour
{
    public static Items Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        placeholder = allItems[allItems.Count - 1];
    }
    
    [SerializeField] private List<Item> allItems = new List<Item>();
    public static Item placeholder;
    public Transform itemWorldRender;
    public Item GetItem(Item.Type type)
    {
        return allItems[(int)type];
    }
}
