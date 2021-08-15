using System;
using System.Collections.Generic;
using UnityEngine;

public class CraftUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] RectTransform arrow;
    [SerializeField] ItemSlotCraft[] itemSlots;

    [Header("Public Variables")]
    public ItemContainer itemContainer;

    private CraftingRecipes craftingRecipes;
    public CraftingRecipes CraftingRecipes
    {
        get { return craftingRecipes;  }
        set { SetCraftingRecipe(value);  }
    }

    public event Action<ItemSlotCraft> OnPointerEnterEvent;
    public event Action<ItemSlotCraft> OnPointerExitEvent;

    private void OnValidate()
    {
        itemSlots = GetComponentsInChildren<ItemSlotCraft>();
    }

    private void Start()
    {
        foreach(ItemSlotCraft itemSlot in itemSlots)
        {
            itemSlot.OnPointerEnterEvent += OnPointerEnterEvent;
            itemSlot.OnPointerExitEvent += OnPointerExitEvent;
        }
    }

    public void OnCraftButtonClick()
    {
        if(craftingRecipes != null && itemContainer != null)
        {
            if (craftingRecipes.CanCraft(itemContainer))
            {
                if (!itemContainer.InvIsFull())
                {
                    craftingRecipes.Craft(itemContainer);
                }
                else
                {
                    Debug.Log("Inventory is Full");
                }
            }
            else
            {
                Debug.Log("You Don't Have The Required Materials");
            }
        }
    }

    private void SetCraftingRecipe(CraftingRecipes newCraftingRecipe)
    {
        craftingRecipes = newCraftingRecipe;

        if (craftingRecipes != null)
        {
            int slotIndex = 0;
            slotIndex = SetSlots(craftingRecipes.Materials, slotIndex);
            arrow.SetSiblingIndex(slotIndex);
            slotIndex = SetSlots(craftingRecipes.Results, slotIndex);

            for (int i = slotIndex; i < itemSlots.Length; i++)
            {
                itemSlots[i].transform.parent.gameObject.SetActive(false);
            }

            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private int SetSlots(IList<ItemAmount> itemAmountsList, int slotIndex)
    {
        for (int i = 0; i < itemAmountsList.Count; i++, slotIndex++)
        {
            ItemAmount itemAmount = itemAmountsList[i];
            ItemSlotCraft itemSlot = itemSlots[slotIndex];

            itemSlot.Item = itemAmount.Item;
            itemSlot.Amount = itemAmount.Amount;
            itemSlot.transform.parent.gameObject.SetActive(true);
        }
        return slotIndex;
    }
}
