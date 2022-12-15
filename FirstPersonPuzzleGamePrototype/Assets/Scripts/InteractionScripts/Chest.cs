using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : InventoryHolder, InterfaceInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private InventoryItemData item;
    [SerializeField] private InventorySlot_UI[] inventorySlots;
    [SerializeField] private DescriptionPromptUI description;

    public string InteractionPrompt => _prompt;

    public static bool chestOpen;

    private bool chestUnlocked; 

    public InventoryItemData keyItem => item;

    public InventorySlot_UI[] invslots => inventorySlots;

    public InventoryItemData storedItem; 

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
            chestUnlocked = true;
            foreach (var slots in invSlot)
            {
                slots.ClearSlot();
                
            }
            for (int i = 0; i < invslots.Length; i++)
            {
                invslots[i].UpdateUISlot();
            }
            description.UpdateDescription("You opened the chest!");
            
            //Debug.Log(chestOpen);

            inventorySystem.AddToInventory(storedItem, 1);
            //calling this event when we interact with it
            OnDynamicInventoryDisplayRequested?.Invoke(inventorySystem);

            return true;

        }

        if(chestUnlocked)
        {
            description.UpdateDescription("the chest is empty");
            OnDynamicInventoryDisplayRequested?.Invoke(inventorySystem);
            return true;
        }

        /*
        we could implement an  EndInteraction function here as part of the interactor
        if we want something to happen at the end of an interaction
        for example: if the player moves away from the chest, you could call a new event (public UnityAction<InterfaceInteractable> OnInteractionComplete {get; set;}) and be listening on that from the UI controller
        and then it closes itself

        for now, we will just keep it simple

         */

        chestOpen = false;
        description.UpdateDescription("Chest is locked! You need a key");
       
        return false;

    }
}
