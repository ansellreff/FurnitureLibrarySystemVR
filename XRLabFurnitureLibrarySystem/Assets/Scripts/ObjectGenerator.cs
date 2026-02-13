using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject SpawnPoint;
    public DisplayObject objectDisplay;
    private  GameObject SpawnObject;



public void GenerateObject()
{
    // Get the current object prefab
    GameObject prefab = objectDisplay.GetCurrentObjectPrefab();

    // Get the BoxCollider component from the prefab
    BoxCollider boxCollider = prefab.GetComponent<BoxCollider>();

    // Calculate the offset based on the BoxCollider's center
    Vector3 offset = boxCollider ? prefab.transform.TransformPoint(boxCollider.center) - prefab.transform.position : Vector3.zero;

    // Calculate the spawn position: the center of the spawn point minus the offset
    Vector3 spawnPosition = SpawnPoint.transform.position - offset;

    // Instantiate the prefab to generate the object
    SpawnObject = Instantiate(prefab, spawnPosition, Quaternion.identity);

    Debug.Log("Object Spawned");
}


}
