using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DestroyTextManager : MonoBehaviour
{
    public static DestroyTextManager Instance { get; private set; }

    public Text DestroyText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowDestroyText()
    {
        DestroyText.text = "Object Deleted!";
        DestroyText.gameObject.SetActive(true);

        // Start the coroutine to hide the text after 2 seconds
        StartCoroutine(HideDestroyText());
    }

    private IEnumerator HideDestroyText()
    {
        yield return new WaitForSeconds(2f);

        // Hide the DestroyText after 2 seconds
        DestroyText.gameObject.SetActive(false);
    }
}
