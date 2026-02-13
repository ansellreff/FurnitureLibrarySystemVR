using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectDestroyer : MonoBehaviour
{
    public InputActionAsset actionAsset;
    private InputAction destroyPressed;

    private XRBaseInteractable interactable;
    private XRController rightHandController;
    private void Start()
    {
        var inputactionMap = actionAsset.FindActionMap("Default");

        destroyPressed = inputactionMap.FindAction("Destroy");
        destroyPressed.performed += DestroyPressed_performed;
        
    }

    private void DestroyPressed_performed(InputAction.CallbackContext obj)
    {
        if (TryGetInteractableObject(out XRBaseInteractable interactable))
        {
            Destroy(interactable.gameObject);
        }
    }

   

    private bool TryGetInteractableObject(out XRBaseInteractable interactable)
    {
        interactable = null;
        RaycastHit hit;
        if (Physics.Raycast(rightHandController.transform.position, rightHandController.transform.forward, out hit))
        {
            interactable = hit.collider.GetComponent<XRBaseInteractable>();
            if (interactable != null)
            {
                return true;
            }
        }
        return false;
    }
}
