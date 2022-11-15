using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq; 

[System.Serializable] //this attribute allows Unity to delve into the members of the class, causing them to show up in the inspector
public class InventorySystem 
{
    [SerializeField] private List<InventorySlot> inventorySlots; //list of inventory slots

    public List<InventorySlot> InventorySlots => inventorySlots; //this is our public getter that we use to point to our prviate list
    public int InventorySize => InventorySlots.Count; //pointing towards the count of our list, keeping them separate and safe

    public UnityAction<InventorySlot> OnInventorySlotChanged; //this will fire off when we add an item to our inventory. 

    //constructor
    public InventorySystem(int size) 
    {
        inventorySlots = new List<InventorySlot>(size);
        //create an inventoryslots list given the size

        for(int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlot());
            //adding inventorySlots to a new InventorySystem
        }
    }

    public bool AddToInventory(InventoryItemData itemToAdd, int amountToAdd)
    {

        if(ContainsItem(itemToAdd, out List<InventorySlot> invSlot)) //checks whether each item exists in the inventory
        {
            foreach(var slot in invSlot) //using a foreach allows for more flexibility since we can have a wide variety of invSlots
            {
                if (slot.RoomLeftInStack(amountToAdd)) //if there is roomLeft for the stack
                {
                    slot.AddToStack(amountToAdd); //if there is already that item in a slot, it will simply add it to the slot stack
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }

        }

        if(HasFreeSlot(out InventorySlot freeSlot)) //if its not in the inventory already, we want to check if we have a free slot
        {
            freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
            OnInventorySlotChanged?.Invoke(freeSlot);
            return true; 
        }
        return false; //this is triggered if we don't already have an item slot existing for it, and if we don't have a free slot
    }


    //takes in the item that we want to add, and passes out the inventorySlot that the item is contained if it exists
    //do any of our slots have the item?
    public bool ContainsItem(InventoryItemData itemToAdd, out List<InventorySlot> invSlot)
    {

        invSlot = InventorySlots.Where(i => i.ItemData == itemToAdd).ToList(); //using LINQ, where our item.itemdata is equal to the item we want to add. 
                                                                               //This checks all of our inventory slots. then it creates a list of inventoryslots and fill it where the invSlot.data = itemToAdd and put that into a list
        //Debug.Log(invSlot.Count);
        if(invSlot.Count == 0) { return false; }
        else if(invSlot.Count > 0) { return true;  }
        //return false; 
        //return invSlot == null ? false : true; 
        return invSlot.Count > 1 ? true : false; //if the invSlot.Count is greater than 1, return true. otherwise, we do not have that item, and thus return false
    }

    public bool ContainsItem(InventoryItemData itemToAdd)
    {
        List<InventorySlot> invSlot = InventorySlots.Where(i => i.ItemData == itemToAdd).ToList(); //using LINQ, where our item.itemdata is equal to the item we want to add. 
                                                                               //This checks all of our inventory slots. then it creates a list of inventoryslots and fill it where the invSlot.data = itemToAdd and put that into a list
        //Debug.Log(invSlot.Count);
        return invSlot == null ? false : true;
        // return invSlot.Count > 1 ? true : false; //if the invSlot.Count is greater than 1, return true. otherwise, we do not have that item, and thus return false
    }



    public bool HasFreeSlot(out InventorySlot freeSlot)
    {
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null); //FirstOrDefault: returns the first element of the sequence that satisfies a condition, or a specified default value if no such element is found
                                                                           //we're just going to get the first slot that has no inventorydata, meaning it is empty and is free
        return freeSlot == null ? false : true;
    }
}
