using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

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
}
