using UnityEngine;
using UnityEngine.UI;

public class ItemToolTip : MonoBehaviour
{

    [SerializeField] Text ItemName;
    [SerializeField] Text ItemSlot;

    public void ShowTip(EquippableItem item)
    {

        ItemName.text = item.ItemName;

        ItemSlot.text = item.EquipType.ToString();

        gameObject.SetActive(true);
    }

    public void HideTip()
    {
        gameObject.SetActive(false);
    }

}
