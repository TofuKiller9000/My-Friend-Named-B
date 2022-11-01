using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInventoryDisplay : InventoryDisplay
{

    [SerializeField] private InventoryHolder InventoryHolder;
    [SerializeField] private InventorySlot_UI[] slots; 

    protected override void Start()
    {
        base.Start();
        if(InventoryHolder != null)
        {
            inventorySystem = InventoryHolder.InventorySystem;
            inventorySystem.OnInventorySlotChanged += UpdateSlot; 
        }

        else
        {
            Debug.LogWarning($"No Inventory assigned to {this.gameObject}");
        }

        AssignSlot(inventorySystem); //passing in our inventoryHolders system from the InventoryDisplay as a protected system
    }
    public override void AssignSlot(InventorySystem invToDisplay)
    {

        //if we wanted we could check to make sure that the inventory system we are parring the Static display with have equal size
        //this would be useful in instances where you might get upgrades for your inventory size, or have a backpack system, but that is not neccessary 

        //if slots.length != inventorysystem.inventorySize    debug.log("error")
        slotDictionary = new Dictionary<InventorySlot_UI, InventorySlot>();
        for (int i = 0; i < inventorySystem.InventorySize; i++)
        {
            slotDictionary.Add(slots[i], inventorySystem.InventorySlots[i]);
            //                 Key       value
            slots[i].Init(inventorySystem.InventorySlots[i]); //the init function takes in an InventorySlot and then assigns it and updates it
        }
    }
}
