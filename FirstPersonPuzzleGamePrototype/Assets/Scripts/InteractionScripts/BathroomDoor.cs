using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomDoor : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private InventoryItemData item;
    [SerializeField] private InventorySlot_UI[] inventorySlots;
    [SerializeField] private DescriptionPromptUI description;

    [SerializeField] private Animator anim;

    public string InteractionPrompt => _prompt;

    public AudioSource doorSound; 

    public bool doorLocked = true;

    public InventoryItemData keyItem => item;

    public InventorySlot_UI[] invslots => inventorySlots;

    public bool Interact(Interactor interactor)
    {
        var myInventory = interactor.GetComponent<InventoryHolder>();

        if (myInventory == null)
        {

            return false;
        }


        if (myInventory.InventorySystem.ContainsItem(keyItem, out List<InventorySlot> invSlot))
        {
            doorSound.Play();
            anim.SetTrigger("Opened");
            description.UpdateDescription("The white key fits perfectly into the lock.");
            doorLocked = false;
            foreach (var slot in invSlot)
            {
                slot.ClearSlot();

            }

            for (int i = 0; i < invslots.Length; i++)
            {
                invslots[i].UpdateUISlot();
                //keyitemslot.UpdateUISlot();
            }
            return true;


        }
        else if(!doorLocked)
        {
            doorSound.Play();
            anim.SetTrigger("Opened");
            return true; 
        }

        description.UpdateDescription("No matter how much you push and shake, the door will not open.");
        return true;
    }
}
