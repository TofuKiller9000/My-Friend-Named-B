using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItems : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private InventoryItemData item;

    //blic List<InventorySlot> InventorySlots => tempIventorySlots; //this is our public getter that we use to point to our prviate list

    public InventoryHolder tempInventory;

    public string InteractionPrompt => _prompt;

    public InventoryItemData keyItem => item;

    public bool Interact(Interactor interactor)
    {

        var myInventory = interactor.GetComponent<InventoryHolder>();
        tempInventory = myInventory; 

        if (myInventory == null)
        {
            Debug.LogError("Inventory not found on interactor");
            return false;
        }


        if (Input.GetKeyDown(KeyCode.E) && tempInventory)
        {
            tempInventory.InventorySystem.AddToInventory(keyItem, 1);
            Debug.Log("You picked up the item");
            Destroy(this.gameObject);
            return true;

        }

        Debug.Log("Unable to pick up item");
        return false;

    }
}