using UnityEngine;

public class MoveOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the environment
        if (collision.gameObject.CompareTag("Environment"))
        {
            // Get the mesh collider of the environment
            MeshCollider environmentCollider = collision.gameObject.GetComponent<MeshCollider>();

            // Calculate the size of the environment's bounds
            Vector3 environmentSize = environmentCollider.bounds.size;

            // Calculate the offset to move the prefab on top of the environment
            float yOffset = environmentSize.y / 2f;

            // Move the prefab on top of the environment
            transform.position = new Vector3(transform.position.x, collision.contacts[0].point.y + yOffset, transform.position.z);
        }
    }
}
