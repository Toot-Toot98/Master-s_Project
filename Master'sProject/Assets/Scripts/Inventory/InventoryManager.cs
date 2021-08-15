using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    [SerializeField] Inventory inventory;
    [SerializeField] Gear gear;
    [SerializeField] CraftWindow craftWindow;
    [SerializeField] ItemToolTip itemToolTip;
    [SerializeField] Image draggableItem;

    private ItemSlotCraft dragItemSlot;

    private void Start()
    {
        if (itemToolTip == null)
        {
            itemToolTip = FindObjectOfType<ItemToolTip>();
        }

        inventory.OnRightClickEvent += Equip;
        gear.OnRightClickEvent += Unequip;

        inventory.OnPointerEnterEvent += ShowTip;
        gear.OnPointerEnterEvent += ShowTip;
        craftWindow.OnPointerEnterEvent += ShowTip;

        inventory.OnPointerExitEvent += HideTip;
        gear.OnPointerExitEvent += HideTip;
        craftWindow.OnPointerExitEvent += HideTip;

        inventory.OnBeginDragEvent += BeginDrag;
        gear.OnBeginDragEvent += BeginDrag;

        inventory.OnEndDragEvent += EndDrag;
        gear.OnEndDragEvent += EndDrag;

        inventory.OnDragEvent += Drag;
        gear.OnDragEvent += Drag;

        inventory.OnDropEvent += Drop;
        gear.OnDropEvent += Drop;
    }

    private void Equip(ItemSlotCraft itemSlot)
    {
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if (equippableItem != null)
        {
            Equip(equippableItem);
        }
    }

    private void Unequip(ItemSlotCraft itemSlot)
    {
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if (equippableItem != null)
        {
            Unequip(equippableItem);
        }
    }

    private void ShowTip(ItemSlotCraft itemSlot)
    {
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if (equippableItem != null)
        {
            itemToolTip.ShowTip(equippableItem);
        }
    }

    private void HideTip(ItemSlotCraft itemSlot)
    {
        itemToolTip.HideTip();
    }

    private void BeginDrag(ItemSlotCraft itemSlot)
    {
        if (itemSlot.Item != null)
        {
            dragItemSlot = itemSlot;
            draggableItem.sprite = itemSlot.Item.Icon;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.gameObject.SetActive(true);
        }
    }

    private void EndDrag(ItemSlotCraft itemSlot)
    {
        dragItemSlot = null;
        draggableItem.enabled = false;
    }

    private void Drag(ItemSlotCraft itemSlot)
    {
        if (draggableItem.enabled)
        {
            draggableItem.transform.position = Input.mousePosition;
        }
    }

    private void Drop(ItemSlotCraft dropItemSlot)
    {
        if (dragItemSlot == null) return;

        if (dropItemSlot.CanRecieveItem(dragItemSlot.Item) && dragItemSlot.CanRecieveItem(dropItemSlot.Item))
        {
            EquippableItem dragItem = dragItemSlot.Item as EquippableItem;
            EquippableItem dropItem = dropItemSlot.Item as EquippableItem;

            if(dropItemSlot is GearSlots)
            {
                if (dragItem != null) Equip(dragItem);
                if (dropItem != null) Unequip(dropItem);
            }
            if (dragItemSlot is GearSlots)
            {
                if (dragItem != null) Unequip(dragItem);
                if (dropItem != null) Equip(dropItem);
            }

            Item draggedItem = dragItemSlot.Item;
            int draggedItemAmount = dragItemSlot.Amount;

            dragItemSlot.Item = dropItemSlot.Item;
            dragItemSlot.Amount = dropItemSlot.Amount;

            dropItemSlot.Item = draggedItem;
            dropItemSlot.Amount = draggedItemAmount;
        }
    }



    void Equip(EquippableItem item)
    {
        if (inventory.RemoveItem(item))
        {
            EquippableItem previousItem;
            if (gear.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    inventory.AddItem(previousItem);
                }
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }

    void Unequip(EquippableItem item)
    {
        if (!inventory.InvIsFull() && gear.RemoveItem(item))
        {
            inventory.AddItem(item);
        }
    }
}
