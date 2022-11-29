using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomDoor : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private InventoryItemData item;
    //[SerializeField] private InventorySlot_UI keyItemSlot;
    [SerializeField] private DescriptionPromptUI description;

    [SerializeField] private Animator anim;
    //[SerializeField] private string _descriptionPromptUI;

    public string InteractionPrompt => _prompt;

    public InventoryItemData keyItem => item;

    //public InventorySlot_UI keyitemslot => keyItemSlot;

    public bool Interact(Interactor interactor)
    {
        anim.SetTrigger("Opened");


        return true;

    }
}
