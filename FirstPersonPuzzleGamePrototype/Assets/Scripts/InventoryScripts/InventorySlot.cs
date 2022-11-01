using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class InventorySlot
{
    [SerializeField] private InventoryItemData itemData; //reference to the data
    [SerializeField] private int stackSize; //current stack size

    //public getters
    public InventoryItemData ItemData => itemData; 
    public int StackSize => stackSize; 


    //constructor to make a occupied inventory slot
    public InventorySlot(InventoryItemData source, int amount)
    {
        itemData = source;
        stackSize = amount; 
    }

    //this is here for when there is no item in our inventory space
    //this is the default empty space
    public InventorySlot()
    {
        ClearSlot();
    }

    //"destructor" 
    public void ClearSlot()
    {
        itemData = null;
        stackSize = -1;
    }

    public void AssignItem(InventorySlot invSlot)
    {
        if(itemData == invSlot.itemData)
        {
            AddToStack(invSlot.stackSize);
        }
        else
        {
            itemData = invSlot.itemData;
            stackSize = 0;
            AddToStack(invSlot.stackSize);
        }
    }

    public void UpdateInventorySlot(InventoryItemData data, int amount)
    {
        itemData = data;
        stackSize = amount; 
    }

    public bool RoomLeftInStack(int amountToAdd, out int amountRemaining)
    {
        amountRemaining = ItemData.maxStackSize - stackSize; 
        return RoomLeftInStack(amountToAdd);
    }

    public bool RoomLeftInStack(int amountToAdd)
    {
        if (stackSize + amountToAdd <= itemData.maxStackSize)
        {
            return true;
        }
        else return false; 
    }

    public void AddToStack(int amount)
    {
        stackSize += amount; 

    }

    public void RemoveFromStack(int amount)
    {
        stackSize -= amount; 
    }
}
