using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using JetBrains.Annotations;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ObjectSelection : XRBaseInteractable
{
    private XRGrabInteractable grabInteractable;
    public string objectType;
    public string objectName;
    public Sprite sprite;


    private void Start()
    {
        objectType=transform.name;
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.onSelectEntered.AddListener(OnGrabbed);
           
        }
    }
    private void OnGrabbed(XRBaseInteractor interactor)
    {
        TMP_Text imageTypeText = GameObject.Find("NameOfObject").GetComponent<TMP_Text>();
        TMP_Text objectNameText =GameObject.Find("TypeOfObject").GetComponent<TMP_Text>();
        Image ObjectImage = GameObject.Find("ObjectImage").GetComponent<Image>();

        // Display the image type and object name in the TextMeshPro objects
         ObjectImage.sprite = sprite; 
        imageTypeText.text = "Type: " + objectType;
        objectNameText.text = "Name: " + objectName;
    }
   
}
