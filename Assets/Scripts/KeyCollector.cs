using UnityEngine;
using System;

public class KeyCollector : MonoBehaviour
{
    private int keysCollected = 0;
    public int totalKeys = 3;
    public GameObject dropZone; // The zone where keys need to be dropped

    public Action onAllKeysDropped; // Action to trigger when all keys are dropped

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            keysCollected++;
            Destroy(other.gameObject); // Optionally destroy the key object or disable it
            Debug.Log("Key collected: " + keysCollected);

            if (keysCollected >= totalKeys)
            {
                Debug.Log("All keys collected! Drop them in the zone.");
                onAllKeysDropped?.Invoke(); // Trigger the action
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DropZone") && keysCollected >= totalKeys)
        {
            Debug.Log("All keys dropped!");
            onAllKeysDropped?.Invoke(); // Trigger the action
        }
    }
}
