using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScreenBarSystem : MonoBehaviour {

    public GameObject bar;
    public Text loadingText;
    public bool backGroundImageAndLoop;
    public float LoopTime;
    public GameObject[] backgroundImages;
    public GameObject[] objectsToHide;  // Add this line to define an array of objects to hide
    [Range(0,1f)]public float vignetteEfectVolue; // Must be a value between 0 and 1
    public float minimumLoadingTime = 2f;  // Add this line to define a minimum display time for the loading bar
    AsyncOperation async;
    Image vignetteEfect;

    // Added method
    public void LoadTitleScene()
    {
        loadingScreen(0);
    }

    public void HideVariantPrefabs()
    {
        // Get all active GameObjects
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        // Iterate over all active GameObjects
        foreach (GameObject obj in allObjects)
        {
            // Check if the GameObject's name contains "Variant"
            if (obj.name.Contains("Variant"))
            {
                // Hide the GameObject
                obj.SetActive(false);
            }
        }
    }

    // Added method
    public void LoadSelectionScene()
    {
    HideVariantPrefabs();
    loadingScreen(1);
    }


    public void loadingScreen (int sceneNo)
    {
        this.gameObject.SetActive(true);

        // Hide all objects in the array
        foreach (GameObject obj in objectsToHide)  // Add this loop to hide all objects in the array
        {
            obj.SetActive(false);
        }

        StartCoroutine(Loading(sceneNo));
    }

    /*
    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            bar.transform.localScale += new Vector3(0.001f,0,0);

            if (loadingText != null)
                loadingText.text = "%" + (100 * bar.transform.localScale.x).ToString("####");
        }
    }
    */

    private void Start()
    {
        vignetteEfect = transform.Find("VignetteEfect").GetComponent<Image>();
        vignetteEfect.color = new Color(vignetteEfect.color.r,vignetteEfect.color.g,vignetteEfect.color.b,vignetteEfectVolue);

        if (backGroundImageAndLoop)
            StartCoroutine(transitionImage());
    }


    IEnumerator transitionImage ()
    {
        for (int i = 0; i < backgroundImages.Length; i++)
        {
            yield return new WaitForSeconds(LoopTime);
            for (int j = 0; j < backgroundImages.Length; j++)
                backgroundImages[j].SetActive(false);
            backgroundImages[i].SetActive(true);           
        }
    }

    IEnumerator Loading(int sceneNo)
    {
        async = SceneManager.LoadSceneAsync(sceneNo);
        async.allowSceneActivation = false;

        float progress = 0;
        float startTime = Time.time;  // Record the start time of the loading process

        while (!async.isDone)
        {
            if (async.progress < 0.9f)
            {
                progress = async.progress;
            }
            else
            {
                progress = Mathf.Lerp(progress, 1f, Time.deltaTime);
                // Only allow scene activation if the minimum loading time has passed
                if (progress > 0.99f && Time.time - startTime > minimumLoadingTime)  // Add this condition to check the minimum loading time
                {
                    async.allowSceneActivation = true;
                }
            }

            bar.transform.localScale = new Vector3(progress, 0.9f, 1);

            if (loadingText != null)
                loadingText.text = "%" + (100 * progress).ToString("####");

            yield return null;
        }
    }


}