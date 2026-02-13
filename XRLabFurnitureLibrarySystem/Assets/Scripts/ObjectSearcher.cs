using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;



public class ObjectSearcher : MonoBehaviour
{
    public float searchRadius = 5f;

    private List<XRGrabInteractable> grabInteractables = new List<XRGrabInteractable>();
    private List<ObjectSelection> selections = new List<ObjectSelection>();


    private void Update()
    {
        SearchForXRGrabInteractable();
    }

    private void SearchForXRGrabInteractable()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, searchRadius);

        foreach (Collider collider in colliders)
        {
            XRGrabInteractable grabInteractable = collider.GetComponent<XRGrabInteractable>();
            ObjectSelection objectSelection = collider.GetComponent<ObjectSelection>();
            
            if (grabInteractable != null && !grabInteractables.Contains(grabInteractable))
            {
                grabInteractables.Add(grabInteractable);
                Debug.Log("Found XRGrabInteractable: " + grabInteractable.gameObject.name);

                grabInteractable.onSelectEntered.AddListener((interactor) => OnGrabbed(grabInteractable));
                grabInteractable.onSelectExited.AddListener((interactor) => OnReleased(grabInteractable));
            }
            
            if (objectSelection != null && !selections.Contains(objectSelection))
            {
                selections.Add(objectSelection);
                Debug.Log("Found SelectionScript: " + objectSelection.gameObject.name);
            }
        }

        if (selections.Count == 0)
        {
            Debug.Log("No SelectionScript components found in the search radius.");
        }
        if (grabInteractables.Count == 0)
        {
            Debug.Log("No XRGrabInteractable components found in the search radius.");
        }
    }


    private void OnGrabbed(XRGrabInteractable grabInteractable)
    {
        // When the object is grabbed, start a coroutine to keep it facing upwards
        // and at the same height
        StartCoroutine(KeepUprightAndFixedHeight(grabInteractable.transform));
        grabInteractable.transform.rotation = Quaternion.Euler(0, grabInteractable.transform.rotation.eulerAngles.y, 0);
    }

    private IEnumerator KeepUprightAndFixedHeight(Transform target)
    {
        // Store the initial Y position
        float initialY = target.position.y;

        // While the object is being grabbed
        while (target.GetComponent<XRGrabInteractable>().isSelected)
        {
            // Keep the object upright
            Vector3 eulerAngles = target.eulerAngles;
            eulerAngles.x = 0;
            eulerAngles.z = 0;
            target.eulerAngles = eulerAngles;

            // Keep the object at the same height
            Vector3 position = target.position;
            position.y = initialY;
            target.position = position;

            yield return null;  // Wait until the next frame
        }
    }


    private void OnReleased(XRGrabInteractable grabInteractable)
    {
        // When the object is released, reset its rotation to face upwards
        grabInteractable.transform.rotation = Quaternion.Euler(0, grabInteractable.transform.rotation.eulerAngles.y, 0);

        Rigidbody rigidbody = grabInteractable.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }


    public void ToggleGrabInteractables()
    {
        foreach (XRGrabInteractable grabInteractable in grabInteractables)
        {
            if (grabInteractable != null)
            {
                grabInteractable.enabled = !grabInteractable.enabled;
            }
        }
        foreach (ObjectSelection objectSelection in selections)
        {
            if (objectSelection != null)
            {
                objectSelection.enabled = !objectSelection.enabled;
            }
        }
    }

    public void DisableToggleGrabInteractables()
    {
        foreach (XRGrabInteractable grabInteractable in grabInteractables)
        {
            if (grabInteractable != null)
            {
                grabInteractable.enabled = false; // This will make sure it can't be grabbed.
            }
        }
        foreach (ObjectSelection objectSelection in selections)
        {
            if (objectSelection != null)
            {
                objectSelection.enabled = !objectSelection.enabled; // This part remains unchanged as it was not specified to change.
            }
        }
    }


}
