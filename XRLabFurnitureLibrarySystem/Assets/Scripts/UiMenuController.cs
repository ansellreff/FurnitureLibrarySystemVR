using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UiMenuController : MonoBehaviour
{
    public InputActionAsset inputActionAsset;
    private InputAction pausePressed;

    public GameObject[] canvases;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var canvas in canvases)
        {
            canvas.SetActive(false);
        }

        var inputActionMap = inputActionAsset.FindActionMap("Default");
        pausePressed = inputActionMap.FindAction("Pause");
        pausePressed.performed += PausePressedPerformed;
        pausePressed.Enable();
    }

    private void PausePressedPerformed(InputAction.CallbackContext obj)
    {
        bool anyCanvasActive = false;

        foreach (var canvas in canvases)
        {
            if (canvas.activeSelf)
            {
                anyCanvasActive = true;
                break;
            }
        }

        foreach (var canvas in canvases)
        {
            canvas.SetActive(!anyCanvasActive);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
