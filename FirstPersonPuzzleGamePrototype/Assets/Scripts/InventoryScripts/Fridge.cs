using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : InventoryHolder, InterfaceInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private InventoryItemData item;
    [SerializeField] private InventorySlot_UI[] inventorySlots;
    [SerializeField] private DescriptionPromptUI description;

    public string InteractionPrompt => _prompt;

    public static bool fridgeOpened;

    public AudioSource fridgeSound;

    public InventoryItemData keyItem => item;

    public InventorySlot_UI[] invslots => inventorySlots;

    public InventoryItemData[] storedItems;

    public bool Interact(Interactor interactor)
    {

        if(fridgeOpened)
        {
            fridgeSound.Play();
            OnDynamicInventoryDisplayRequested?.Invoke(inventorySystem);
            return true;
        }
        else
        {
            for(int i = 0; i < storedItems.Length; i++)
            {
                inventorySystem.AddToInventory(storedItems[i], 1);
                
            }
            fridgeSound.Play();
            OnDynamicInventoryDisplayRequested?.Invoke(inventorySystem);
            fridgeOpened = true; 
            return true;
        }


    }
}
