using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private InventoryItemData item;
    [SerializeField] private InventorySlot_UI[] inventorySlots;
    [SerializeField] private DescriptionPromptUI description;

    [SerializeField] private Animator anim;
    //[SerializeField] private string _descriptionPromptUI;

    public string InteractionPrompt => _prompt;

    public GameObject spawnItem;

    public AudioSource SafeAudio;

    public AudioClip Error;

    public AudioClip Correct; 

    public InventoryItemData keyItem => item;

    public InventorySlot_UI[] invslots => inventorySlots;

    public bool Interact(Interactor interactor)
    {
        SafeAudio = gameObject.GetComponent<AudioSource>();
        var myInventory = interactor.GetComponent<InventoryHolder>();

        if (myInventory == null)
        {

            return false;
        }


        if (myInventory.InventorySystem.ContainsItem(keyItem, out List<InventorySlot> invSlot))
        {
            SafeAudio.clip = Correct;
            SafeAudio.Play();
            spawnItem.SetActive(true);
            anim.SetTrigger("Opened");
            description.UpdateDescription("Pressing 4-2-0-6-9 into the keypad, the safe swings open!");
            foreach (var slot in invSlot)
            {
                slot.ClearSlot();
                
            }


            for (int i = 0; i < invslots.Length; i++)
            {
                invslots[i].UpdateUISlot();
                
            }

            gameObject.GetComponent<Collider>().enabled = false; 
            return true;


        }

        SafeAudio.clip = Error;
        SafeAudio.Play();
        description.UpdateDescription("You're going to need the code to open this safe.");
        return true;

    }
}
