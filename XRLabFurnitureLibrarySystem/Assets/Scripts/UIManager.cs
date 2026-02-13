using UnityEngine;
using UnityEngine.UI; // To access Text

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public Text GrabbedObjectName;

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
}