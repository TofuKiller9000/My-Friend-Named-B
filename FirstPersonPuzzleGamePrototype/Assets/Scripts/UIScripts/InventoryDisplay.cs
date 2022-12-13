
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem; 

//Abstract Classes
//Both a MonoBehaviour and an Interface at the same time
//they cannot be instanced or a component on a GameObject in a scene
//you are allowed to have methods that must be present in inherited classes; you are allowed to add variables and methods with parameters
//
//
public abstract class InventoryDisplay : MonoBehaviour
{
    [SerializeField] MouseItemData mouseInventoryItem; //set this in the inspector

    protected InventorySystem inventorySystem; //this is going to be the inventory system we want to display
    protected Dictionary<InventorySlot_UI, InventorySlot> slotDictionary; //here, we are marrying a Slot_UI and a slot together in a dictionary form; by using a dictionary, we can pass in the UI and get the slot that it is married to
    
    

    //public getters
    public InventorySystem MyInventorySystem => inventorySystem; //our public getter to our protected variable
    public Dictionary<InventorySlot_UI, InventorySlot> mySlotDictionary => slotDictionary;

    protected virtual void Start()
    {

    }

    public abstract void AssignSlot(InventorySystem invToDisplay);

    //This method is virtual and thus can be overriden in child classes


    protected virtual void UpdateSlot(InventorySlot updatedSlot)
    {
        foreach (var slot in slotDictionary)
        {
            if(slot.Value == updatedSlot) //slot value - the "under the hood" inventory slot
            {
                slot.Key.UpdateUISlot(updatedSlot); //slot key - the ui representation of the value
                //if the value of the slot that we have passed in is equal to the value of a slot in our dicitionary then we will update the uiSlot that corresponds to it
                //InventorySlot_UI is the key
            }
        }
    }

    public void SlotClicked(InventorySlot_UI clickedSlot)
    {
        //clicked slot has an item - mouse doesn't have an item - then pick up that item
        if (clickedSlot.AssignedInventorySlot.ItemData != null && mouseInventoryItem.mouseInventoryItem.ItemData == null)
        {
            mouseInventoryItem.UpdateMouseSlot(clickedSlot.AssignedInventorySlot);
            clickedSlot.ClearSlot();
            return;
        }


        //clicked slot doesn't have an item - mouse does have an item - place the mouse item into the empty slot

        if(clickedSlot.AssignedInventorySlot.ItemData == null && mouseInventoryItem.mouseInventoryItem.ItemData != null)
        {
            clickedSlot.AssignedInventorySlot.AssignItem(mouseInventoryItem.mouseInventoryItem);
            clickedSlot.UpdateUISlot();

            mouseInventoryItem.ClearSlot();
        }

        //both slots have an item - 


        //Debug.Log("Slot has been clicked");
    }
}
