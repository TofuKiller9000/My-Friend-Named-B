using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

[System.Serializable]
public class InventoryHolder : MonoBehaviour
{
    [SerializeField] private int inventorySize; //this will be set in the inspector
    [SerializeField] protected InventorySystem inventorySystem; //by default all inventory holders will have one inventorysystems on them
                                                                //since this is a protected variable, it is accessible in InventoryHolder and all classes derived from it

    public InventorySystem InventorySystem => inventorySystem; //creating a pointer variable

    public static UnityAction<InventorySystem> OnDynamicInventoryDisplayRequested;

    private void Awake()
    {
        inventorySystem = new InventorySystem(inventorySize);
        //creating a new inventory system, established in "InventorySystem.cs"
    }
}
