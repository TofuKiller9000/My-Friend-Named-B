using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private InventoryItemData item;

    public string InteractionPrompt => _prompt;

    public static bool chestOpen; 

    public InventoryItemData keyItem => item; 

    public bool Interact(Interactor interactor)
    {

        var myInventory = interactor.GetComponent<InventoryHolder>();

        if (myInventory == null)
        {
            Debug.LogError("Inventory not found on interactor");
            return false;
        }


        if (myInventory.InventorySystem.ContainsItem(keyItem, out List<InventorySlot> invSlot))
        {
            chestOpen = true;
            Debug.Log("You opened the chest!");
            //Debug.Log(chestOpen);
            return true;

        }

        chestOpen = false; 
        Debug.Log("Chest is locked! You need a key");
        return false;

    }
}
