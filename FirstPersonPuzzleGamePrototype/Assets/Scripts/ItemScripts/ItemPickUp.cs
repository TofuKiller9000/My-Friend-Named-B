using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickUp : MonoBehaviour
{
    public GameObject instruction; 
    public float PickUpRadius = 1f;
    public InventoryItemData ItemData;
    public InventoryHolder tempInventory; 
    private SphereCollider myCollider;
    public bool action = false; 


    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = PickUpRadius;
        instruction.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //should I have done this with raycasting? yes. yes I should have. But to be fair, didn't know that actually existed. Probably will add that in the next iteration because this technically works
        instruction.SetActive(true);
        action = true;  
        var inventory = other.transform.GetComponent<InventoryHolder>(); //this is looking for an inventory holder of the thing that it hit
        tempInventory = inventory;    
            
    }

    private void OnTriggerExit(Collider other)
    {
        instruction.SetActive(false);
        action = false; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (action == true)
            {
                if (!tempInventory) return;

                if (tempInventory.InventorySystem.AddToInventory(ItemData, 1))
                {
                    //Destroy(this.gameObject);
                   // instruction.SetActive(false);
                }
            }
        }
    }
}
