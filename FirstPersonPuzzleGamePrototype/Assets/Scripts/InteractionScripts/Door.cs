using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<InventoryHolder>();

        Debug.Log("Door is locked!");
        return true; 
    }
}
