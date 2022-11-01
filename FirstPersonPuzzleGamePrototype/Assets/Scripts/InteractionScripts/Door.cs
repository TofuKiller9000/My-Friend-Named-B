using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private InventoryItemData item;

    //blic List<InventorySlot> InventorySlots => tempIventorySlots; //this is our public getter that we use to point to our prviate list

    //public InventoryHolder tempInventory;

    public string InteractionPrompt => _prompt;

    public InventoryItemData keyItem => item; 

    public bool Interact(Interactor interactor)
    {

        var myInventory = interactor.GetComponent<InventoryHolder>();

        if(myInventory == null) 
        {
            Debug.LogError("Inventory not found on interactor");
            return false;  
        }


       if (myInventory.InventorySystem.ContainsItem(keyItem, out List<InventorySlot> invSlot))
       {

           Debug.Log("Door Unlocked!");
           return true;

       }

        Debug.Log("Door is locked. You Need a Key!");
        return false; 
        
    }
}
