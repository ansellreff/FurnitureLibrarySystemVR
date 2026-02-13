using UnityEngine;

public class ScreenshotNotification : MonoBehaviour
{
    public GameObject floatingTextPrefab;
    public float displayDuration = 3f;
    public float floatSpeed = 1f;

    public Vector3 spawnOffset = new Vector3(0f, 1f, 0f);

    private void Start()
    {
        // Disable the floating text initially
        if (floatingTextPrefab != null)
        {
            floatingTextPrefab.SetActive(false);
        }
    }

    public void ShowFloatingText()
    {
        if (floatingTextPrefab != null)
        {
            // Calculate the spawn position for the floating text
            Vector3 spawnPosition = transform.position + spawnOffset;

            // Create an instance of the floating text prefab at the desired position
            GameObject floatingTextInstance = Instantiate(floatingTextPrefab, spawnPosition, Quaternion.identity);

            // Set the parent of the floating text instance to this object
            floatingTextInstance.transform.SetParent(transform, false);

            // Activate the floating text instance
            floatingTextInstance.SetActive(true);

            // Set the display duration for the floating text
            Destroy(floatingTextInstance, displayDuration);

            // Apply floating upward motion to the floating text instance
            Rigidbody floatingTextRigidbody = floatingTextInstance.GetComponent<Rigidbody>();
            if (floatingTextRigidbody != null)
            {
                floatingTextRigidbody.velocity = new Vector3(0f, floatSpeed, 0f);
            }
        }
    }
}
