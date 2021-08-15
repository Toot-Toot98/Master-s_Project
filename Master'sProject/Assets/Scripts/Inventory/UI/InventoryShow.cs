using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryShow: MonoBehaviour
{

    public static bool IsInventoryShown;
    public KeyCode Key = KeyCode.Tab;
    public GameObject InventoryUI;

    void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            if (IsInventoryShown)
            {
                Resume();
            }
            else
            {
                ShowInventory();
            }
        }
    }

    void Resume()
    {

        InventoryUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        IsInventoryShown = false;

    }
    
    void ShowInventory()
    {

        InventoryUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        IsInventoryShown = true;

    }
}
