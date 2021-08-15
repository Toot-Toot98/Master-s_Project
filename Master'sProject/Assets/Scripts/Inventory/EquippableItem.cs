using UnityEngine;

public enum EquipType
{
    Helmet,
    Chest,
    Legs,
    Weapon,
}

[CreateAssetMenu]
public class EquippableItem : Item
{

    public EquipType EquipType;


    public override Item GetCopy()
    {
        return Instantiate(this);
    }

    public override void Destroy()
    {
        Destroy(this);
    }
}
