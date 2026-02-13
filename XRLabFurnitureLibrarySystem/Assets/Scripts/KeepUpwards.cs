using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class KeepUpwards : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable == null)
        {
            Debug.LogError("No XRGrabInteractable component found on this object.");
        }
        else
        {
            grabInteractable.onSelectEntered.AddListener(OnGrabbed);
            grabInteractable.onSelectExited.AddListener(OnReleased);
        }
    }

    private void OnGrabbed(XRBaseInteractor interactor)
    {
        // Keep the object upright
        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles.x = 0;
        eulerAngles.z = 0;
        transform.eulerAngles = eulerAngles;

        // Store the original rotation
        Quaternion originalRotation = transform.rotation;

        // Freeze the object's position
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }

        // Start a coroutine to restore the original rotation after a delay
        StartCoroutine(RestoreRotation(transform, originalRotation));
    }

    private IEnumerator RestoreRotation(Transform target, Quaternion originalRotation)
    {
        // Wait for a delay
        yield return new WaitForSeconds(1f);

        // While the object is being grabbed
        while (target.GetComponent<XRGrabInteractable>().isSelected)
        {
            // Restore the original rotation
            target.rotation = originalRotation;
            yield return null;  // Wait until the next frame
        }
    }


    private void OnReleased(XRBaseInteractor interactor)
    {
        // When the object is released, reset its rotation to face upwards
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        // Unfreeze the object's position
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.constraints = RigidbodyConstraints.None;
        }
    }
}
