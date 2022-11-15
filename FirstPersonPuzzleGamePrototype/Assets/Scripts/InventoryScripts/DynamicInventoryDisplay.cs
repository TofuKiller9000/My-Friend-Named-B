using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class DynamicInventoryDisplay : InventoryDisplay
{
    [SerializeField] protected InventorySlot_UI slotPrefab; 

 
    protected override void Start()
    {
        base.Start();
    }


    public void RefreshDynamicInventory(InventorySystem invToDisplay)
    {
        ClearSlots(); //clears out any old slots
        inventorySystem = invToDisplay; //update the inventory to display
        AssignSlot(invToDisplay); //then it is going to assign those slots in assignSlots
    }

    //assigning our chest ui
    public override void AssignSlot(InventorySystem invToDisplay)
    {
        //ClearSlots(); //first we clear the previous slots

        slotDictionary = new Dictionary<InventorySlot_UI, InventorySlot>(); //create a new slotDictionary

        if (invToDisplay == null) return; //cancel out here if it does not have an inventory

        for(int i = 0; i < invToDisplay.InventorySize; i++)
        {
            var uiSlot = Instantiate(slotPrefab, transform);
            slotDictionary.Add(uiSlot, invToDisplay.InventorySlots[i]); //pairing the slots to their ui representations
            uiSlot.Init(invToDisplay.InventorySlots[i]); //initialize the uislots
            uiSlot.UpdateUISlot(); //update the slotUI to display the correct items
        }
        //fill our slot dictionary with our uiSlots and pairing it with the actual slots

    }
    //when we open the inventorydisplay of one chest, then close, and then open the inventory of ANOTHER chest, we need to clear the previous slots and display the correct number of slots
    private void ClearSlots()
    {
        //this is going to sit on the top level object and it is going tog et all the ui slots and destroy them
        foreach(var item in transform.Cast<Transform>())
        {
            Destroy(item.gameObject);
            //techniqually not the best way of doing this, as instead we should just disable them and then keep them in a pool of items, but I don't want to do that
        }

        if(slotDictionary != null)
        {
            slotDictionary.Clear();
        }
    }
}
