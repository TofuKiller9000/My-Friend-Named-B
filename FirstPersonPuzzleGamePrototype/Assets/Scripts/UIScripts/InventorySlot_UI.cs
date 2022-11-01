using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class InventorySlot_UI : MonoBehaviour
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private InventorySlot assignedInventorySlot;

    private Button myButton;

    public InventorySlot AssignedInventorySlot => assignedInventorySlot; //public getter
    public InventoryDisplay ParentDisplay { get; private set; }

    private void Awake()
    {

        ClearSlot();

        myButton = GetComponent<Button>();
        myButton?.onClick.AddListener(OnUiSlotClock); //if it isn't null, we are going to subscribe to its onClick event

        ParentDisplay = transform.parent.GetComponent<InventoryDisplay>();
    }
    
    //initializing with a slot
    public void Init(InventorySlot slot)
    {
        assignedInventorySlot = slot;
        UpdateUISlot(slot);
    }
    
    public void UpdateUISlot(InventorySlot slot)
    {
        if(slot.ItemData != null)
        {
            itemSprite.sprite = slot.ItemData.icon;
            itemSprite.color = Color.white;

            if (slot.StackSize > 1)
            {
                itemCount.text = slot.StackSize.ToString();
                //if we only have 1 of the item, we won't display the number
            }
            else
            {
                itemCount.text = "";
            }
        }
        else
        {
            ClearSlot(); //if for some reason we pass in an item that has no data attached to it, we'll just clear the slot
        }

        if(slot.StackSize > 1)
        {
            itemCount.text = slot.StackSize.ToString();
            //if we only have 1 of the item, we won't display the number
        }
        else
        {
            itemCount.text = "";
        }
    }

    //create a method that does not take in an inventory slot
    //we may just want to refresh without having to actually send it another slot
    public void UpdateUISlot()
    {
        if(assignedInventorySlot != null)
        {
            UpdateUISlot(assignedInventorySlot);
        }
    }

    //"destructor"
    public void ClearSlot()
    {
        assignedInventorySlot?.ClearSlot();
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        itemCount.text = "";
    }

    public void OnUiSlotClock()
    {
        //access display class function
        ParentDisplay?.SlotClicked(this); 
    }
}
