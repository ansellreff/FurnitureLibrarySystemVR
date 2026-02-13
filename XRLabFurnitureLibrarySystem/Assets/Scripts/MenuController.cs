using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;
    public GameObject HouseCataloguePanel;
    public GameObject furnitureCataloguePanel;
    public GameObject IntroPanel;
    public GameObject EditInfoPanel;
    public GameObject furnitureTypeSelection;
    private SpawnPointController spawnPointController;
    private string House1String = "House1";
    private string House2String = "House2";
    private string House3String = "House3";
    private string House4String = "House4";
    private string House5String = "House5";
    private string House6String = "House6";
    private string House7String = "House7";
    private string House8String = "House8";
    private string House9String = "House9";
    private string House10String = "House10";
    private string House11String = "House11";
    private string House12String = "House12";
    private string House13String = "House13";
    private string House14String = "House14";
    private string House15String = "House15";
    private string House16String = "House16";
    private string House17String = "House17";
    private string House18String = "House18";
    private string House19String = "House19";
    private string House20String = "House20";
    private string House21String = "House21";
    private string House22String = "House22";
    private string House23String = "House23";
    private string House24String = "House24";
    private string House25String = "House25";
    private string House26String = "House26";
    private string House27String = "House27";
    private string House28String = "House28";
    private string House29String = "House29";
    private string House30String = "House30";
    private string SelectionString = "Selection";


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        // Initialize spawnPointController - replace "SpawnPoint" with the name of your spawn point GameObject
        GameObject spawnPoint = GameObject.Find("SpawnPoint");
        if(spawnPoint != null)
        {
            spawnPointController = spawnPoint.GetComponent<SpawnPointController>();
        }
        if(spawnPointController != null)
        {
            spawnPointController.ShowSpawnPoint(true);
        }
    }
   
    public void ShowEditInfoPanel()
    {
        if (!EditInfoPanel.activeSelf)
        {
            CloseAllPanels();
            EditInfoPanel.SetActive(true);
            
            // Hide the DestroyText
            DestroyTextManager.Instance.DestroyText.gameObject.SetActive(false);
        }
        else if (!HouseCataloguePanel.activeSelf && !furnitureCataloguePanel.activeSelf && !IntroPanel.activeSelf)
        {
            EditInfoPanel.SetActive(true);
            CloseAllPanels();
            
            // Hide the DestroyText
            DestroyTextManager.Instance.DestroyText.gameObject.SetActive(false);
        }
    }


    public void ShowHouseCatalogue()
    {
        if (!HouseCataloguePanel.activeSelf)
        {
            CloseAllPanels();
            HouseCataloguePanel.SetActive(true);
        }
        else if (!EditInfoPanel.activeSelf && !furnitureCataloguePanel.activeSelf && !IntroPanel.activeSelf)
        {
            HouseCataloguePanel.SetActive(true);
            CloseAllPanels();
        }
    }

    public void ShowFurnitureCatalogue()
    {
        if (!furnitureCataloguePanel.activeSelf)
        {
            EditMode.instance.EnableLocomotion();
            CloseAllPanels();
            furnitureTypeSelection.SetActive(true);
            if(spawnPointController != null)
            {
                spawnPointController.ShowSpawnPoint(true); // show the spawn point
            }
        }
        else if (!EditInfoPanel.activeSelf && !HouseCataloguePanel.activeSelf && !IntroPanel.activeSelf)
        {
            furnitureCataloguePanel.SetActive(true);
            furnitureTypeSelection.SetActive(true);
            CloseAllPanels();
            if(spawnPointController != null)
            {
                spawnPointController.ShowSpawnPoint(true); // show the spawn point
            }
        }
    }

    public void ShowIntroPanel()
    {
        if (!IntroPanel.activeSelf)
        {
            CloseAllPanels();
            IntroPanel.SetActive(true);
        }
        else if (!EditInfoPanel.activeSelf && !HouseCataloguePanel.activeSelf && !furnitureCataloguePanel.activeSelf)
        {
            IntroPanel.SetActive(true);
            CloseAllPanels();
        }
    }


    private void CloseAllPanels()
    {
        EditInfoPanel.SetActive(false);
        HouseCataloguePanel.SetActive(false);
        furnitureCataloguePanel.SetActive(false);
        IntroPanel.SetActive(false);
        furnitureTypeSelection.gameObject.SetActive(false);
        if(spawnPointController != null)
        {
            spawnPointController.ShowSpawnPoint(false); // hide the spawn point
        }
    }
    public void ExitGame()
    {
        StartCoroutine(ExitGameWithDelay());
    }

    private IEnumerator ExitGameWithDelay()
    {
        yield return new WaitForSeconds(2);
        Application.Quit();
    }

    public void ExitHouse()
    {
        StartCoroutine(ExitHouseWithDelay());
    }

    private IEnumerator ExitHouseWithDelay()
    {
        yield return new WaitForSeconds(3);
        if(SceneManager.GetActiveScene().name==House1String || 
        SceneManager.GetActiveScene().name == House2String || 
        SceneManager.GetActiveScene().name == House3String ||
        SceneManager.GetActiveScene().name == House4String ||
        SceneManager.GetActiveScene().name == House5String ||
        SceneManager.GetActiveScene().name == House6String ||
        SceneManager.GetActiveScene().name == House7String ||
        SceneManager.GetActiveScene().name == House8String ||
        SceneManager.GetActiveScene().name == House9String ||
        SceneManager.GetActiveScene().name == House10String ||
        SceneManager.GetActiveScene().name == House11String ||
        SceneManager.GetActiveScene().name == House12String ||
        SceneManager.GetActiveScene().name == House13String ||
        SceneManager.GetActiveScene().name == House14String ||
        SceneManager.GetActiveScene().name == House15String ||
        SceneManager.GetActiveScene().name == House16String ||
        SceneManager.GetActiveScene().name == House17String ||
        SceneManager.GetActiveScene().name == House18String ||
        SceneManager.GetActiveScene().name == House19String ||
        SceneManager.GetActiveScene().name == House20String ||
        SceneManager.GetActiveScene().name == House21String ||
        SceneManager.GetActiveScene().name == House22String ||
        SceneManager.GetActiveScene().name == House23String ||
        SceneManager.GetActiveScene().name == House24String ||
        SceneManager.GetActiveScene().name == House25String ||
        SceneManager.GetActiveScene().name == House26String ||
        SceneManager.GetActiveScene().name == House27String ||
        SceneManager.GetActiveScene().name == House28String ||
        SceneManager.GetActiveScene().name == House29String ||
        SceneManager.GetActiveScene().name == House30String)
        {
            SceneManager.LoadScene("Selection");
        }
        if (SceneManager.GetActiveScene().name == SelectionString)
        {
            Application.Quit();
        }
    }
    public void ExitHouseSelection()
    {
        StartCoroutine(ExitHouseSelectionWithDelay());
    }

    private IEnumerator ExitHouseSelectionWithDelay()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Title");
    }  
    public void ShowSelectionButton()
    {

        furnitureCataloguePanel.SetActive(true);

       
    }
  
}

