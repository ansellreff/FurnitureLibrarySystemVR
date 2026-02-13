using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ImageNavigator : MonoBehaviour
{
    public List<Sprite> images;
    public Image imageDisplay;
    private int currentImageIndex = 0;

    private void Start()
    {
        UpdateImage();
    }

    public void NextImage()
    {
        currentImageIndex++;
        if (currentImageIndex >= images.Count)
            currentImageIndex = 0;

        UpdateImage();
    }

    public void PreviousImage()
    {
        currentImageIndex--;
        if (currentImageIndex < 0)
            currentImageIndex = images.Count - 1;

        UpdateImage();
    }

    private void UpdateImage()
    {
        imageDisplay.sprite = images[currentImageIndex];
    }
}
