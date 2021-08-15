using UnityEngine;

public class ItemAdd : MonoBehaviour
{

    [SerializeField] Item item;
    [SerializeField] Inventory inventory;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] KeyCode pickUpItem = KeyCode.E;

    private bool inRange = false;

    private void OnValidate()
    {
        if (inventory == null)
        {
            inventory = FindObjectOfType<Inventory>();
        }

        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        spriteRenderer.sprite = item.Icon;
    }

    private void Update()
    {
        if (Input.GetKeyDown(pickUpItem) && inRange)
        {
            Item itemCopy = item.GetCopy();
            inventory.AddItem(itemCopy);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }
}
