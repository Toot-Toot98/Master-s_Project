using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeUIShow : MonoBehaviour
{
    public GameObject CraftingWindow;
    public KeyCode key = KeyCode.F;

    private bool IsInRange = false;
    private bool CraftShow;

    private void Update()
    {
        if (Input.GetKeyDown(key) && IsInRange)
        {
            if (CraftShow)
            {
                Resume();
            }
            else
            {
                ShowCraftUI();
            }
        }
    }

    void Resume()
    {
        CraftingWindow.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        CraftShow = false;
    }

    void ShowCraftUI()
    {
        CraftingWindow.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        CraftShow = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        IsInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        IsInRange = false;
    }

}
