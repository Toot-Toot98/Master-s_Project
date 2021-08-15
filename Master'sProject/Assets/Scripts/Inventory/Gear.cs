using UnityEngine;
using System;

public class Gear : MonoBehaviour
{

    [SerializeField] Transform gearSlotParent;
    [SerializeField] GearSlots[] gearSlots;

    public event Action<ItemSlotCraft> OnRightClickEvent;
    public event Action<ItemSlotCraft> OnBeginDragEvent;
    public event Action<ItemSlotCraft> OnEndDragEvent;
    public event Action<ItemSlotCraft> OnDragEvent;
    public event Action<ItemSlotCraft> OnDropEvent;
    public event Action<ItemSlotCraft> OnPointerEnterEvent;
    public event Action<ItemSlotCraft> OnPointerExitEvent;

    private void Awake()
    {
        for (int i = 0; i < gearSlots.Length; i++)
        {
            gearSlots[i].OnRightClickEvent += OnRightClickEvent;
            gearSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            gearSlots[i].OnEndDragEvent += OnEndDragEvent;
            gearSlots[i].OnDragEvent += OnDragEvent;
            gearSlots[i].OnDropEvent += OnDropEvent;
            gearSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
            gearSlots[i].OnPointerExitEvent += OnPointerExitEvent;
        }
    }

    private void OnValidate()
    {
        gearSlots = gearSlotParent.GetComponentsInChildren<GearSlots>();
    }

    public bool AddItem(EquippableItem item, out EquippableItem previousItem)
    {
        for (int i = 0; i < gearSlots.Length; i++)
        {
            if (gearSlots[i].EquipType == item.EquipType)
            {
                previousItem = (EquippableItem)gearSlots[i].Item;
                gearSlots[i].Item = item;
                return true;
            }
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(EquippableItem item)
    {
        for (int i = 0; i < gearSlots.Length; i++)
        {
            if (gearSlots[i].Item == item)
            {
                gearSlots[i].Item = null;
                return true;
            }
        }
        return false;
    }

}
