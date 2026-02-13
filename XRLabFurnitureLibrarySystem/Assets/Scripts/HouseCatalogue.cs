using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class HouseCatalogues
{
    public Sprite sprite;
    public string name;
    public GameObject HouseName;
}

public class HouseCatalogue : MonoBehaviour
{
    public HouseCatalogues[] catalogues;
    public Image objectImage;
    public Text objectNumberText;
    public Text objectNameText;
    public LoadingScreenBarSystem loadingScreenBarSystem;
    
    private int index = 0;

    void Start()
    {
        DisplayHouse(index);
    }

    public void onNextpressed()
    {
        index++;
        if (index >= catalogues.Length)
        {
            index = 0;
        }
        DisplayHouse(index);
    }

    public void onPreviousPressed()
    {
        index--;
        if (index < 0)
        {
            index = catalogues.Length - 1;
        }
        DisplayHouse(index);
    }

    private void DisplayHouse(int index)
    {
        HouseCatalogues currentDisplayObject = catalogues[index];
        objectImage.sprite = currentDisplayObject.sprite;
        objectNumberText.text = currentDisplayObject.name;
        objectNameText.text = currentDisplayObject.name;
    }

    public void LoadHouse()
    {
        loadingScreenBarSystem.loadingScreen(index + 2);
    }
}
