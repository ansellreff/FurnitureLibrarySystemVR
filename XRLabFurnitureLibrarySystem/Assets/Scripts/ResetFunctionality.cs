using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetFunctionality : MonoBehaviour
{
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
