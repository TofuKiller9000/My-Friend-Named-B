using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toliet : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private InventoryItemData item;
    [SerializeField] private InventorySlot_UI[] inventorySlots;
    [SerializeField] private DescriptionPromptUI description;
    //[SerializeField] private string _descriptionPromptUI;

    public string InteractionPrompt => _prompt;

    public AudioSource TolietAudio; 

    public InventoryItemData keyItem => item;

    public InventorySlot_UI[] invslots => inventorySlots;

    public bool Interact(Interactor interactor)
    {
        var myInventory = interactor.GetComponent<InventoryHolder>();

        TolietAudio = gameObject.GetComponent<AudioSource>();

        if (myInventory == null)
        {

            return false;
        }

        if (myInventory.InventorySystem.ContainsItem(keyItem, out List<InventorySlot> invSlot))
        {
            TolietAudio.Play();
            description.UpdateDescription("Using the toliet paper as a protective shield, you reach down to the bottom and grab what feels like a hard rock. Looking it over, you find a small piece of paper that simply reads 'Check the trash'");
            foreach (var slot in invSlot)
            {
                slot.ClearSlot();
            }

            for (int i = 0; i < invslots.Length; i++)
            {
                invslots[i].UpdateUISlot();
                //keyitemslot.UpdateUISlot();
            }
            gameObject.GetComponent<Collider>().enabled = false; 
            return true;
        }
        description.UpdateDescription("A disgusting toliet. You think you see something at the bottom, but you'd want something to protect your hands before you go diving down there.");
        return true;


    }
}
