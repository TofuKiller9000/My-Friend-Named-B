using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterfaceInteractable 
{
    public string InteractionPrompt { get;  }
    public InventoryItemData keyItem { get;  }

    //public int ID; //ID number 
    public bool Interact(Interactor interactor);
}
