using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class Interactor : MonoBehaviour
{
    //public InventoryItemData ItemData;
    //public InventoryHolder tempInventory;

    //public InventoryHolder myInventory; 
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound; //number of colliders we've actually found, make serialized for debugging


    private void Update()
    {
        //computes and stores colliders touching or inside the sphere into the provided buffer
        //we are using this as opposed to OverlapSphere so that it dopesn't generate any garbage; its a little slower but thats alright
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask); //will return an int
                                                 //center of the sphere      //radius of the sphere   //the buffer(3)   //a layer mask which defines which layers of collider to include in the query
        if(_numFound > 0)
        {
            var interactable = _colliders[0].GetComponent<InterfaceInteractable>();
            if(interactable != null && Keyboard.current.eKey.wasPressedThisFrame) //using the new input system from UnityEngine.InputSystem
            {
                interactable.Interact(this);
            }
        }
    }

    //OnDrawGizmos draws Gizmos (i think thats the purple muppet guy) that are pickable + drawn
    //Uses mouse position that is relative to the scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius); //hey this is just like OpenGL
    }
}
