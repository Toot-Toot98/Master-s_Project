using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot :ItemSlotCraft, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    public event Action<ItemSlotCraft> OnBeginDragEvent;
    public event Action<ItemSlotCraft> OnEndDragEvent;
    public event Action<ItemSlotCraft> OnDragEvent;
    public event Action<ItemSlotCraft> OnDropEvent;

    public override bool CanRecieveItem(Item item)
    {
        return false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (OnBeginDragEvent != null)
        {
            OnBeginDragEvent(this);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (OnEndDragEvent != null)
        {
            OnEndDragEvent(this);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragEvent != null)
        {
            OnDragEvent(this);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (OnDropEvent != null)
        {
            OnDropEvent(this);
        }
    }
}
