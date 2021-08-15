using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemAmount
{
    public Item Item;
    [Range(1,100)]
    public int Amount;
}

[CreateAssetMenu]
public class CraftingRecipes : ScriptableObject
{

    public List<ItemAmount> Materials;
    public List<ItemAmount> Results;

    public bool CanCraft(IItemContainer itemContainer)
    {
        //Debug.Log("Can Craft");
        foreach (ItemAmount itemAmount in Materials)
        {
            //Debug.Log("Craft" + itemAmount.Amount + " " + itemAmount.Item.ID + " " + itemContainer.ItemCount(itemAmount.Item.ID));

            if (itemContainer.ItemCount(itemAmount.Item.ID) < itemAmount.Amount)
            {
                //Debug.Log("Retuns False");
                return false;
                
            }
        }
        return true;
    }

    public void Craft(IItemContainer itemContainer)
    {

        if (CanCraft(itemContainer))
        {
            foreach (ItemAmount itemAmount in Materials)
            {
                for (int i = 0; i < itemAmount.Amount; i++)
                {
                    Item oldItem = itemContainer.RemoveItem(itemAmount.Item.ID);
                    oldItem.Destroy();
                }
            }

            foreach (ItemAmount itemAmount in Results)
            {
                for (int i = 0; i < itemAmount.Amount; i++)
                {
                    itemContainer.AddItem(itemAmount.Item.GetCopy());
                }
            }

        }

    }

}
