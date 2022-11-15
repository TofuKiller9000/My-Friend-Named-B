using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MouseItemData : MonoBehaviour
{
    public Image ItemSprite;
    public TextMeshProUGUI ItemCount;
    public InventorySlot mouseInventoryItem; 

    private void Awake()
    {
        ItemSprite.color = Color.clear;
        ItemCount.text = "";

    }

    public void UpdateMouseSlot(InventorySlot invSlot)
    {
        mouseInventoryItem.AssignItem(invSlot);
        ItemSprite.sprite = invSlot.ItemData.icon;
        ItemCount.text = invSlot.StackSize.ToString();
        ItemSprite.color = Color.white; 
    }

    public void ClearSlot()
    {
        mouseInventoryItem.ClearSlot();
        ItemCount.text = "";
        ItemSprite.color = Color.clear;
        ItemSprite.sprite = null;
    }

    public void Update()
    {
      
        //checking if our mouse actually has an inventory item 
        if(mouseInventoryItem.ItemData != null)
        {
            //set the item's sprite to the mouse's posision
            transform.position = Mouse.current.position.ReadValue();

            if(Mouse.current.leftButton.wasPressedThisFrame && !IsPointerOverUIObject())
            {
                ClearSlot();
                //right now this will drop it out of our inventory; we might change this in the future to just display a warning sign
            }
        }

    }

    //thanks stackOverflow
    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);

        eventDataCurrentPosition.position = Mouse.current.position.ReadValue(); //we're gonna get the eventData's position and set that to the mouse's current position
        List<RaycastResult> results = new List<RaycastResult>(); 
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);//return a list of items that have UI elements associated with them. shouldn't effect any other items in the game world
        return results.Count > 0; //if it is greater than 0, that means we are hovering over a UI element
    }
}
