using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableReference : MonoBehaviour
{
    private void Awake()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            XRInteractionManager interactionManager = FindObjectOfType<XRInteractionManager>();
            grabInteractable.interactionManager = interactionManager;
        }
    }
}
