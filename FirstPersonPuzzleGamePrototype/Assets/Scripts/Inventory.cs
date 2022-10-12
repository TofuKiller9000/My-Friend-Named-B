using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Inventory : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            GameObject itemPickUp = other.gameObject; //temporarily make another game object
            Item item = itemPickUp.GetComponent<Item>();
            AddItem(item.id, item.type, item.description, item.icon);
        }
    }

    void AddItem(int itemID, string itemType, string itemDescription, Texture2D itemIcon)
    {

    }
}
