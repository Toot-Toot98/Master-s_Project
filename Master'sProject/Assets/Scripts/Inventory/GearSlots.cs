using UnityEngine;

public class GearSlots : ItemSlot
{

    public EquipType EquipType;

    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name = EquipType.ToString() + " Slot";
    }

    public override bool CanRecieveItem(Item item)
    {
        if (item == null)
        {
            return true;
        }

        EquippableItem equippableItem = item as EquippableItem;
        return equippableItem != null && equippableItem.EquipType == EquipType;
    }

}
