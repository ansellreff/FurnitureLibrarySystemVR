using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EditMode : MonoBehaviour
{
    public static EditMode instance;
    public LocomotionSystem system;
    public ActionBasedContinuousTurnProvider actionBasedContinousTurnProvider;
    public ActionBasedContinuousMoveProvider actionBasedContinuousMoveProvider;
    public bool isLocomotionEnabled = true;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        UpdateLocomotionState();
    }


    public void ToggleLocomotionFromUI()
    {
        if (isLocomotionEnabled)
        {
            DisableLocomotion();
            Update();
        }
        else
        {
            EnableLocomotion();
            Update();
        }
    }

    public void EnableLocomotion()
    {
        if (!isLocomotionEnabled)
        {
            system.enabled = true;
            actionBasedContinuousMoveProvider.enabled = true;
            actionBasedContinousTurnProvider.enabled = true;
            isLocomotionEnabled = true;
            Update();
            Debug.Log("Locomotion system enabled");
        }
    }

    public void DisableLocomotion()
    {
        if (isLocomotionEnabled)
        {
            system.enabled = false;
            actionBasedContinuousMoveProvider.enabled = false;
            actionBasedContinousTurnProvider.enabled = false;
            isLocomotionEnabled = false;
            Update();
            Debug.Log("Locomotion system disabled");
        }
    }

    private void UpdateLocomotionState()
    {
        if (isLocomotionEnabled)
        {
            if (!actionBasedContinuousMoveProvider.enabled || !actionBasedContinousTurnProvider.enabled)
            {
                actionBasedContinuousMoveProvider.enabled = true;
                actionBasedContinousTurnProvider.enabled = true;
            }
        }
        else
        {
            if (actionBasedContinuousMoveProvider.enabled || actionBasedContinousTurnProvider.enabled)
            {
                actionBasedContinuousMoveProvider.enabled = false;
                actionBasedContinousTurnProvider.enabled = false;
            }
        }
    }
    
}