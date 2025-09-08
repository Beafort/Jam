using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    private Item item;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public static ItemWorld SpawnItemWorld(Vector3 pos, Item item)
    {
        Debug.Log("In ItemWOrld");
        Transform transform = Instantiate(Items.Instance.itemWorldRender, pos, Quaternion.identity);
        Debug.Log("In ItemWOrld1");
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        if (itemWorld == null) { Debug.Log("IW null"); }
        itemWorld.SetItem(item);
        Debug.Log("In ItemWOrld2");
        return itemWorld;
    }
    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.itemSprite;
       
        BoxCollider2D bc = GetComponent<BoxCollider2D>();

        if (spriteRenderer.sprite != null)
        {
            bc.size = spriteRenderer.sprite.bounds.size;
            bc.offset = spriteRenderer.sprite.bounds.center;
        }

    }

    public Item GetItem() { return item; }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
