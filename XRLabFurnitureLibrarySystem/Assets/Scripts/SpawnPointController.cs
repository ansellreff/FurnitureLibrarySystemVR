using UnityEngine;

public class SpawnPointController : MonoBehaviour
{
    void Start()
    {
        // Deactivate the spawn point at the start of the game
        gameObject.SetActive(false);
    }

    // Function to control the visibility of the spawn point
    public void ShowSpawnPoint(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
