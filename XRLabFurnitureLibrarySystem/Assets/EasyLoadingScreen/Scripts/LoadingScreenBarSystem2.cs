using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScreenBarSystem2 : MonoBehaviour {

    public GameObject bar;
    public Text loadingText;
    public bool backGroundImageAndLoop;
    public float LoopTime;
    public GameObject[] backgroundImages;
    [Range(0,1f)]public float vignetteEfectVolue; // Must be a value between 0 and 1
    public GameObject ExitGameButton;
    public GameObject Title;
    public GameObject StartGame;
    AsyncOperation async;
    Image vignetteEfect;


    public void loadingScreen (int sceneNo)
    {
        this.gameObject.SetActive(true);
        ExitGameButton.SetActive(false);
        Title.SetActive(false);
        StartGame.SetActive(false);
        HideAllExceptXROrigin();
        StartCoroutine(Loading(sceneNo));
    }

    private void HideAllExceptXROrigin()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        GameObject xrOrigin = GameObject.Find("XROrigin");

        foreach (GameObject go in allObjects)
        {
            // Exclude XROrigin and its children
            if (go == xrOrigin || go.transform.IsChildOf(xrOrigin.transform))
            {
                continue;
            }

            go.SetActive(false);
        }
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

    while (!async.isDone)
    {
        // Track actual progress (from 0 to 0.9)
        if (async.progress < 0.9f)
        {
            progress = async.progress;
        }
        else
        {
            // Fake progress from 0.9 to 1.0
            progress = Mathf.Lerp(progress, 1f, Time.deltaTime);
            if (progress > 0.99f) // If progress is close enough to 1
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
