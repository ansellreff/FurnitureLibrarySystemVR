using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private XRRayInteractor interactor;
    [SerializeField] private TeleportationProvider teleportationProvider;
    private InputAction thumbstick;

    public bool IsActive { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        interactor.enabled = false;


        var activate = actionAsset.FindActionMap("XRI RightHand Locomotion").FindAction("Teleport Mode Activate");
        activate.Enable();
        activate.performed += OnTeleportActivate;

        var cancel = actionAsset.FindActionMap("XRI RightHand Locomotion").FindAction("Teleport Mode Cancel");
        cancel.Enable();
        cancel.performed += Cancel_performed;

        thumbstick = actionAsset.FindActionMap("XRI RightHand Locomotion").FindAction("Move");
        thumbstick.Enable();

    }

    private void Cancel_performed(InputAction.CallbackContext obj)
    {
        interactor.enabled = false;
    }

    private void OnTeleportActivate(InputAction.CallbackContext obj)
    {
        interactor.enabled = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (!IsActive)
        {
            return;
        }
           
        if(!thumbstick.triggered)
        {
            return;
        }

        if(!interactor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            interactor.enabled = false;    
            IsActive = false;
            return;
        }

        TeleportRequest teleportRequest = new TeleportRequest()
        {
            destinationPosition = hit.point,
        };

        teleportationProvider.QueueTeleportRequest(teleportRequest);
    }


}
