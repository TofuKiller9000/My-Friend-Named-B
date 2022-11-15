using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private InventoryItemData item; 
    [SerializeField] private InventorySlot keyItemSlot;

    //blic List<InventorySlot> InventorySlots => tempIventorySlots; //this is our public getter that we use to point to our prviate list

    //public InventoryHolder tempInventory;

    public string InteractionPrompt => _prompt;

    public InventoryItemData keyItem => item;


    //public InventorySlot keyItemSlot = tempInventory.InventorySystem.ContainsItem(keyItem); 

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
            keyItemSlot.ClearSlot();
           Debug.Log("You shoot the last remaining bullet from your gun and break the chains!");
           return true;

       }

        Debug.Log("A set of thick chains block you from leaving. You'll need something to get rid of them");
        return false; 
        
    }
}
