using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItems : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private InventoryItemData item;
    [SerializeField] private DescriptionPromptUI description;

    //blic List<InventorySlot> InventorySlots => tempIventorySlots; //this is our public getter that we use to point to our prviate list

    public InventoryHolder tempInventory;

    public AudioSource itemPickUpSound; 

    public string InteractionPrompt => _prompt;

    public InventoryItemData keyItem => item;

    public bool Interact(Interactor interactor)
    {

        var myInventory = interactor.GetComponent<InventoryHolder>();
        tempInventory = myInventory; 

        if (myInventory == null)
        {
            Debug.LogError("Inventory not found on interactor");
            return false;
        }


        if (Input.GetKeyDown(KeyCode.E) && tempInventory)
        {
            itemPickUpSound.Play();
            tempInventory.InventorySystem.AddToInventory(keyItem, 1);
            description.UpdateDescription(keyItem.description);
            //Debug.Log("You picked up the item");
            Destroy(this.gameObject);
            return true;

        }

        Debug.Log("Unable to pick up item");
        return false;

    }
}
