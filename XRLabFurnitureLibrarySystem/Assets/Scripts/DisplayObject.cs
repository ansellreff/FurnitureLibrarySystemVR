using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[System.Serializable]
public class DisplayObjectData
{
    public Sprite sprite;
    public string name;
    public string type;
    public GameObject prefab;
}

[System.Serializable]
public class DisplayObjectCategory
{
    public string categoryName;
    public DisplayObjectData[] displayObjects;
}

public class DisplayObject : MonoBehaviour
{
    public DisplayObjectCategory[] displayObjectCategories;
    public Image objectImage;
    public Text objectNameText;
    public Text objectTypeText;

    private string currentCategory;
    private DisplayObjectData[] filteredObjects;
    private int currentIndex = 0;
    public GameObject FurnitureCataloguePanel;

    private void Start()
    {
        if (displayObjectCategories.Length > 0)
        {
            filteredObjects = displayObjectCategories[0].displayObjects;
            ObjectDisplay(currentIndex);
        }
        else
        {
            Debug.LogError("No display object categories have been assigned.");
        }
    }

    public void NextObject()
    {
        currentIndex++;
        currentIndex = WrapIndex(currentIndex, filteredObjects.Length);

        ObjectDisplay(currentIndex);
    }

    public void PreviousObject()
    {
        currentIndex--;
        currentIndex = WrapIndex(currentIndex, filteredObjects.Length);

        ObjectDisplay(currentIndex);
    }

    public GameObject GetCurrentObjectPrefab()
    {
        return filteredObjects[currentIndex].prefab;
    }

    private void ObjectDisplay(int index)
    {
        DisplayObjectData currentDisplayObject = filteredObjects[index];

        objectImage.sprite = currentDisplayObject.sprite;
        objectNameText.text = currentDisplayObject.name;
        objectTypeText.text = currentDisplayObject.type;
    }

    public void SelectCategory(string category)
    {
        DisplayObjectCategory selectedCategory = displayObjectCategories.FirstOrDefault(cat => cat.categoryName == category);

        if (selectedCategory != null)
        {
            filteredObjects = selectedCategory.displayObjects;
            currentCategory = category;
            currentIndex = 0;
            ObjectDisplay(currentIndex);
            MenuController.instance.furnitureTypeSelection.SetActive(false);
            FurnitureCataloguePanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning($"Category {category} not found. Falling back to first category.");
            filteredObjects = displayObjectCategories[0].displayObjects;
            currentCategory = displayObjectCategories[0].categoryName;
            currentIndex = 0;
            ObjectDisplay(currentIndex);
        }
    }

    private int WrapIndex(int index, int arrayLength)
    {
        if (index >= arrayLength)
            return 0;
        else if (index < 0)
            return arrayLength - 1;
        else
            return index;
    }
}
