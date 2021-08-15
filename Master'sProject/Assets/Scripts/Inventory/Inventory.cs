using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : ItemContainer
{

    [SerializeField] List<Item> startItems;
    [SerializeField] Transform itemParent;

    public event Action<ItemSlotCraft> OnRightClickEvent;
    public event Action<ItemSlotCraft> OnBeginDragEvent;
    public event Action<ItemSlotCraft> OnEndDragEvent;
    public event Action<ItemSlotCraft> OnDragEvent;
    public event Action<ItemSlotCraft> OnDropEvent;
    public event Action<ItemSlotCraft> OnPointerEnterEvent;
    public event Action<ItemSlotCraft> OnPointerExitEvent;

    private void Start()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].OnRightClickEvent += OnRightClickEvent;
            itemSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            itemSlots[i].OnEndDragEvent += OnEndDragEvent;
            itemSlots[i].OnDragEvent += OnDragEvent;
            itemSlots[i].OnDropEvent += OnDropEvent;
            itemSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
            itemSlots[i].OnPointerExitEvent += OnPointerExitEvent;
        }

        SetStartItems();

    }

    private void OnValidate()
    {
        if (itemParent != null)
        {
            itemSlots = itemParent.GetComponentsInChildren<ItemSlot>();
        }

        SetStartItems();
    }

    void SetStartItems()
    {
        int i = 0;
        for (; i < startItems.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = startItems[i].GetCopy();
            itemSlots[i].Amount = 1;
        }

        for (; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
            itemSlots[i].Amount = 0;
        }
    }
}