using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class RotateOnSecondaryButton : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    public InputActionAsset inputActionAsset;
    private InputAction rotatePressed;

    private void Start()
    {
        var inputMap = inputActionAsset.FindActionMap("Default");

        rotatePressed = inputMap.FindAction("Rotate");
        rotatePressed.performed += RotatePressed_performed;
        rotatePressed.Enable();

        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.onSelectEntered.AddListener(OnGrabbed);
            grabInteractable.onSelectExited.AddListener(OnReleased);
        }
    }

    private void RotatePressed_performed(InputAction.CallbackContext obj)
    {
        if(grabInteractable.isSelected)
        {
            grabInteractable.gameObject.transform.Rotate(new Vector3(0, 45, 0));
            Debug.Log("Object Rotated");
        }
    }

    private void OnGrabbed(XRBaseInteractor interactor)
    {
        Debug.Log("Object is being interacted with");
    }

    private void OnReleased(XRBaseInteractor interactor)
    {
        Debug.Log("Object is released");
    }
}
