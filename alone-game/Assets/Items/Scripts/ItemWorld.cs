using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    private ItemInstance item;
    private SpriteRenderer spriteRenderer;
    private static readonly float randDistance = 2f;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public static ItemWorld SpawnItemWorld(Vector3 pos, ItemInstance item)
    {
        Transform transform = Instantiate(ItemManager.Instance.itemWorldRender, pos, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        if (itemWorld == null) { Debug.Log("IW null"); }
        itemWorld.SetItem(item);
        return itemWorld;
    }

    public static ItemWorld DropItem(Vector3 pos, ItemInstance item)
    {
        float angle = Random.Range(0f, Mathf.PI * 2f);
        Vector3 randDir = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle));
        randDir *= randDistance;
        return SpawnItemWorld(pos+randDir, item);
    }
    public void SetItem(ItemInstance item)
    {
        if (item == null || item == ItemManager.placeholderItemInstance)
        {
            Debug.Log("item null");
            return;
        }
        this.item = item;
        spriteRenderer.sprite = item.GetItemData().GetSprite();
        BoxCollider2D bc = GetComponent<BoxCollider2D>();;
        if (spriteRenderer.sprite != null)
        {
            bc.size = spriteRenderer.sprite.bounds.size;
            bc.offset = spriteRenderer.sprite.bounds.center;
        }

    }

    public ItemInstance GetItem() { return item; }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
