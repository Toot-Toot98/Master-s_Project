using System;
using System.Collections.Generic;
using UnityEngine;

public class CraftWindow : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CraftUI craftUIPrefab;
    [SerializeField] RectTransform recipeUIParent;
    [SerializeField] List<CraftUI> craftRecipeUIs;

    [Header("Public Variables")]
    public ItemContainer itemContainer;
    public List<CraftingRecipes> craftingRecipes;

    public event Action<ItemSlotCraft> OnPointerEnterEvent;
    public event Action<ItemSlotCraft> OnPointerExitEvent;

    private void OnValidate()
    {
        Init();
    }

    private void Start()
    {
        Init();

        foreach (CraftUI craftingRecipeUI in craftRecipeUIs)
        {
            craftingRecipeUI.OnPointerEnterEvent += OnPointerEnterEvent;
            craftingRecipeUI.OnPointerExitEvent += OnPointerExitEvent;
        }
    }

    private void Init()
    {
        recipeUIParent.GetComponentsInChildren<CraftUI>();
        UpdateCraftingRecipes();
    }

    public void UpdateCraftingRecipes()
    {
        for (int i = 0; i < craftingRecipes.Count; i++)
        {
            if (craftRecipeUIs.Count == i)
            {
                craftRecipeUIs.Add(Instantiate(craftUIPrefab, recipeUIParent, false));
            }
            else if (craftRecipeUIs[i] == null)
            {
                craftRecipeUIs[i] = Instantiate(craftUIPrefab, recipeUIParent, false);
            }

            craftRecipeUIs[i].itemContainer = itemContainer;
            craftRecipeUIs[i].CraftingRecipes = craftingRecipes[i];
        }

        for (int i = craftingRecipes.Count; i < craftRecipeUIs.Count; i++)
        {
            craftRecipeUIs[i].CraftingRecipes = null;
        }
    }

}
