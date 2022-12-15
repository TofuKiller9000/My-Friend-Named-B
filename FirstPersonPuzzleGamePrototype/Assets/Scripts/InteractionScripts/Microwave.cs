using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private InventoryItemData item;
    [SerializeField] private InventorySlot_UI[] inventorySlots;
    [SerializeField] private DescriptionPromptUI description;

    [SerializeField] private Animator anim;
    //[SerializeField] private string _descriptionPromptUI;

    public GameObject spawnItem;

    public AudioSource microwaveSound; 

    public string InteractionPrompt => _prompt;

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
            spawnItem.SetActive(true);
            microwaveSound.Play();
            anim.SetTrigger("Open");
            description.UpdateDescription("You place the ice cube in the microwave and watch as it melts away to reveal a key");
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
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("MicrowaveDoor"))
        {
            anim.SetTrigger("Close");
            return true; 
        }
        anim.SetTrigger("Open");
        return true;

    }
}
