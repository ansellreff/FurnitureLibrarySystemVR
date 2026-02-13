using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.UI; // To access Button and Text

public class DeleteFunctionality : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    public InputActionAsset inputActionAsset;
    private InputAction destroyPressed;
    private InputAction pausePressed;

    private bool isGrabbed = false;
    private const float rotationAngle = 45f;

    private float cooldownTimer = 0f;
    private const float cooldownDuration = 0.5f; // Half a second cooldown

    private Text GrabbedObjectName; // reference to the UI Text object

    private void Start()
    {
        var inputMap = inputActionAsset.FindActionMap("Default");

        destroyPressed = inputMap.FindAction("Destroy");
        destroyPressed.performed += DestroyPressed_performed;
        destroyPressed.Enable();

        pausePressed = inputMap.FindAction("Pause1");
        pausePressed.performed += PausePressedPerformed;
        pausePressed.Enable();

        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.onSelectEntered.AddListener(OnGrabbed);
            grabInteractable.onSelectExited.AddListener(OnReleased);
        }

        // Assign the GameObject by finding it in the scene

        
        GrabbedObjectName.gameObject.SetActive(false); // initially hide the text
    }

    private void Update()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime; // Reduce the cooldown over time
        }
    }

    private void DestroyPressed_performed(InputAction.CallbackContext obj)
    {
        if (grabInteractable.isSelected)
        {
            Destroy(grabInteractable.gameObject);
            Debug.Log("Object Destroyed");

            // Hide the GrabbedObjectName when the object is destroyed
            UIManager.Instance.GrabbedObjectName.gameObject.SetActive(false);

            // Show the DestroyText
            DestroyTextManager.Instance.ShowDestroyText();
        }
    }


    private void PausePressedPerformed(InputAction.CallbackContext obj)
    {
        if (cooldownTimer <= 0f)
        {
            // Find the CameraButton
            GameObject cameraButtonObject = GameObject.Find("CameraButton");

            if (cameraButtonObject != null)
            {
                Button cameraButton = cameraButtonObject.GetComponent<Button>();

                if (cameraButton != null)
                {
                    // Invoke the button's onClick event
                    cameraButton.onClick.Invoke();
                    Debug.Log("CameraButton clicked");
                }
                else
                {
                    Debug.LogError("No Button component found on CameraButton");
                }
            }
            else
            {
                Debug.LogError("CameraButton not found");
            }

            cooldownTimer = cooldownDuration; // Start the cooldown
        }
    }

    private void OnGrabbed(XRBaseInteractor interactor)
    {
        isGrabbed = true;
        string objectName = grabInteractable.name;
        string strippedName = objectName.Replace("normalized_", "").Replace(" Variant(Clone)", "");
        UIManager.Instance.GrabbedObjectName.text = strippedName; // set the text
        UIManager.Instance.GrabbedObjectName.gameObject.SetActive(true); // show the text
    }

    private void OnReleased(XRBaseInteractor interactor)
    {
        isGrabbed = false;
        Debug.Log("Object is released");
        UIManager.Instance.GrabbedObjectName.gameObject.SetActive(false); // hide the text
    }

}