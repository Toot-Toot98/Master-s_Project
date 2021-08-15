using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlotCraft : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public event Action<ItemSlotCraft> OnRightClickEvent;
    public event Action<ItemSlotCraft> OnPointerEnterEvent;
    public event Action<ItemSlotCraft> OnPointerExitEvent;

    private Color normalColor = Color.white;
    private Color disabledColor = new Color(1, 1, 1, 0);


    [SerializeField] Image image;
    [SerializeField] Text stackAmount;

    private Item _Item;
    public Item Item
    {
        get { return _Item; }
        set
        {
            _Item = value;

            if (_Item == null)
            {
                image.color = disabledColor;
            }
            else
            {
                image.sprite = _Item.Icon;
                image.color = normalColor;
            }
        }
    }

    private int _amount;
    public int Amount
    {
        get { return _amount; }
        set
        {
            _amount = value;
            stackAmount.enabled = _Item != null && _Item.MaxStack > 1 && _amount > 1;
            if (stackAmount.enabled)
            {
                stackAmount.text = _amount.ToString();
            }
        }
    }

    protected virtual void OnValidate()
    {
        if (image == null)
            image = GetComponent<Image>();

        if (stackAmount == null)
            stackAmount = GetComponentInChildren<Text>();
    }

    public virtual bool CanRecieveItem(Item item)
    {
        return false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (OnRightClickEvent != null)
            {
                OnRightClickEvent(this);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (OnPointerEnterEvent != null)
        {
            OnPointerEnterEvent(this);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (OnPointerExitEvent != null)
        {
            OnPointerExitEvent(this);
        }
    }
}
