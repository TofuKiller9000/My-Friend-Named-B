using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{

    public DynamicInventoryDisplay inventoryPanel;

    private void Awake()
    {
        inventoryPanel.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        InventoryHolder.OnDynamicInventoryDisplayRequested += DisplayInventory; //receives the request to display the dynamic inventory
    }

    private void OnDisable()
    {
        InventoryHolder.OnDynamicInventoryDisplayRequested -= DisplayInventory;
    }


    void DisplayInventory(InventorySystem invToDisplay)
    {
        Debug.Log(Chest.chestOpen);
        if(Chest.chestOpen == true)
        {
            Debug.Log("Open Chest");
            inventoryPanel.gameObject.SetActive(true); //sets the panel to active
            inventoryPanel.RefreshDynamicInventory(invToDisplay);
        }

    }
}
