using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Inventory Item")] //since the script is not monob, we use this to be able to debug in the inspector
public class InventoryItemData : ScriptableObject
{
    public Sprite icon; //sprite for the items icon
    public int maxStackSize; //max number of items in a stack
    public int ID; //ID number 
    public string displayName; //display name
    public string description; //what will be shown to the player
}
